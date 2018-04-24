using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
    public class Server
    {
        private TcpListener server;
        private List<Client> clients;
        public Server()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            this.server = new TcpListener(ipAddress, 8888);
            clients = new List<Client>();
        }

        public delegate void onDisconnectDelegate(Client cli);

        public event onDisconnectDelegate onDisconnect;
        public void Start()
        {
            server.Start();
            var syncObj = new ManualResetEvent(false);
            while (true)
            {
                syncObj.Set();
                server.BeginAcceptSocket((IAsyncResult ar) => {
                    var client = new Client();
                    clients.Add(client);
                    client.Socket =
                        ((Socket)ar.AsyncState).EndAccept(ar);
                    syncObj.Reset();
                    Console.WriteLine("connection accepted:" + client.ToString());
                    client.Socket.
                    BeginReceive(client.buffer, 0,
                                    client.buffer.Length, SocketFlags.None, new AsyncCallback(EndReceive), client);
                }, server.Server);
            }
        }

        public void EndReceive(IAsyncResult ar1)
        {
            var client = ((Client)ar1.AsyncState);
            var readed = client.Socket.EndReceive(ar1);
            var cli = (Client)ar1.AsyncState;
            if (readed == 0)
            {
                onDisconnect.Invoke(cli);
            }
            else
            {
                Console.WriteLine(Encoding.ASCII.GetString(client.buffer));
                foreach(Client cl in clients)
                {
                        SendClient(cl, cl.buffer);
                }

                new MemoryStream().
                    Write(client.buffer, 0, readed);

                client.Socket.
                    BeginReceive(client.buffer, 0,
                                    client.buffer.Length, SocketFlags.None, EndReceive, client);
            }
        }

        public void SendClient(Client cli, byte[] data)
        {
            cli.Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), cli);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Client client = (Client)ar.AsyncState;
                Socket handler = client.Socket;
                
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client {1}.", bytesSent, client.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class Client
    {
        internal byte[] buffer = new byte[1024];

        public Guid Id { get; } = Guid.NewGuid();

        public Socket Socket
        {
            get; internal set;
        }

        public override string ToString()
        {
            return String.Format(
                $"{this.Socket.RemoteEndPoint.ToString()}:{this.Id}");
        }

    }

}

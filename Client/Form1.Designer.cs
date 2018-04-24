namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.clientsListView = new System.Windows.Forms.ListView();
            this.chatListView = new System.Windows.Forms.ListView();
            this.sendButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(168, 326);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(348, 86);
            this.messageTextBox.TabIndex = 0;
            // 
            // clientsListView
            // 
            this.clientsListView.Location = new System.Drawing.Point(12, 12);
            this.clientsListView.Name = "clientsListView";
            this.clientsListView.Size = new System.Drawing.Size(150, 400);
            this.clientsListView.TabIndex = 1;
            this.clientsListView.UseCompatibleStateImageBehavior = false;
            // 
            // chatListView
            // 
            this.chatListView.Location = new System.Drawing.Point(168, 12);
            this.chatListView.Name = "chatListView";
            this.chatListView.Size = new System.Drawing.Size(448, 308);
            this.chatListView.TabIndex = 2;
            this.chatListView.UseCompatibleStateImageBehavior = false;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(522, 326);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(94, 39);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "Disconect";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 424);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatListView);
            this.Controls.Add(this.clientsListView);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ListView clientsListView;
        private System.Windows.Forms.ListView chatListView;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button button2;
    }
}


namespace Server
{
    partial class FrmServerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.btStartServer = new System.Windows.Forms.Button();
            this.btStopServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbOnlineUser = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbChatContent = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tslOnlineUserNum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器端口：";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(169, 14);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(100, 21);
            this.tbServerPort.TabIndex = 1;
            this.tbServerPort.TextChanged += new System.EventHandler(this.tbServerPort_TextChanged);
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(275, 12);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(75, 23);
            this.btStartServer.TabIndex = 2;
            this.btStartServer.Text = "开启服务器";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Location = new System.Drawing.Point(367, 12);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(75, 23);
            this.btStopServer.TabIndex = 3;
            this.btStopServer.Text = "停止服务器";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.btStopServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btStopServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btStartServer);
            this.groupBox1.Controls.Add(this.tbServerPort);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 284);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端连接监听";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbOnlineUser);
            this.groupBox2.Location = new System.Drawing.Point(6, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 237);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "在线用户列表";
            // 
            // lbOnlineUser
            // 
            this.lbOnlineUser.FormattingEnabled = true;
            this.lbOnlineUser.ItemHeight = 12;
            this.lbOnlineUser.Location = new System.Drawing.Point(6, 20);
            this.lbOnlineUser.Name = "lbOnlineUser";
            this.lbOnlineUser.Size = new System.Drawing.Size(188, 208);
            this.lbOnlineUser.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbChatContent);
            this.groupBox3.Location = new System.Drawing.Point(212, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 237);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "聊天内容";
            // 
            // rbChatContent
            // 
            this.rbChatContent.Location = new System.Drawing.Point(7, 21);
            this.rbChatContent.Name = "rbChatContent";
            this.rbChatContent.Size = new System.Drawing.Size(253, 207);
            this.rbChatContent.TabIndex = 0;
            this.rbChatContent.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "在线用户人数：";
            // 
            // tslOnlineUserNum
            // 
            this.tslOnlineUserNum.AutoSize = true;
            this.tslOnlineUserNum.Location = new System.Drawing.Point(108, 303);
            this.tslOnlineUserNum.Name = "tslOnlineUserNum";
            this.tslOnlineUserNum.Size = new System.Drawing.Size(77, 12);
            this.tslOnlineUserNum.TabIndex = 6;
            this.tslOnlineUserNum.Text = "onlineNumber";
            // 
            // FrmServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 322);
            this.Controls.Add(this.tslOnlineUserNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmServerMain";
            this.Text = "聊天室服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServerMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbOnlineUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rbChatContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tslOnlineUserNum;
    }
}


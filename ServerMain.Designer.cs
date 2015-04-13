﻿namespace Server
{
    partial class ServerMain
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
            this.btStartServer = new System.Windows.Forms.Button();
            this.btStopServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbChatContent = new System.Windows.Forms.RichTextBox();
            this.lvShowStudent = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(184, 12);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(75, 23);
            this.btStartServer.TabIndex = 2;
            this.btStartServer.Text = "开启服务器";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Location = new System.Drawing.Point(265, 12);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(75, 23);
            this.btStopServer.TabIndex = 3;
            this.btStopServer.Text = "停止服务器";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.btStopServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbChatContent);
            this.groupBox1.Controls.Add(this.lvShowStudent);
            this.groupBox1.Controls.Add(this.btStopServer);
            this.groupBox1.Controls.Add(this.btStartServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 298);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端连接监听";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "导出数据";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rbChatContent
            // 
            this.rbChatContent.Location = new System.Drawing.Point(8, 20);
            this.rbChatContent.Name = "rbChatContent";
            this.rbChatContent.Size = new System.Drawing.Size(152, 19);
            this.rbChatContent.TabIndex = 0;
            this.rbChatContent.Text = "";
            // 
            // lvShowStudent
            // 
            this.lvShowStudent.GridLines = true;
            this.lvShowStudent.Location = new System.Drawing.Point(8, 66);
            this.lvShowStudent.Name = "lvShowStudent";
            this.lvShowStudent.Size = new System.Drawing.Size(470, 212);
            this.lvShowStudent.TabIndex = 8;
            this.lvShowStudent.UseCompatibleStateImageBehavior = false;
            this.lvShowStudent.View = System.Windows.Forms.View.Details;
            this.lvShowStudent.Visible = false;
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 322);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServerMain";
            this.Text = "聊天室服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServerMain_FormClosing);
            this.Load += new System.EventHandler(this.ServerMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvShowStudent;
        private System.Windows.Forms.RichTextBox rbChatContent;
        private System.Windows.Forms.Button button1;

    }
}


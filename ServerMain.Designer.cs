namespace Server
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
            this.btDataFromDB = new System.Windows.Forms.Button();
            this.rbChatContent = new System.Windows.Forms.RichTextBox();
            this.lvShowStudent = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStartServer
            // 
            this.btStartServer.Location = new System.Drawing.Point(184, 33);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(75, 23);
            this.btStartServer.TabIndex = 2;
            this.btStartServer.Text = "开启服务器";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Location = new System.Drawing.Point(265, 33);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(75, 23);
            this.btStopServer.TabIndex = 3;
            this.btStopServer.Text = "停止服务器";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.btStopServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDataFromDB);
            this.groupBox1.Controls.Add(this.rbChatContent);
            this.groupBox1.Controls.Add(this.lvShowStudent);
            this.groupBox1.Controls.Add(this.btStopServer);
            this.groupBox1.Controls.Add(this.btStartServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 359);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端连接监听";
            // 
            // btDataFromDB
            // 
            this.btDataFromDB.Location = new System.Drawing.Point(346, 33);
            this.btDataFromDB.Name = "btDataFromDB";
            this.btDataFromDB.Size = new System.Drawing.Size(75, 23);
            this.btDataFromDB.TabIndex = 9;
            this.btDataFromDB.Text = "导出数据";
            this.btDataFromDB.UseVisualStyleBackColor = true;
            // 
            // rbChatContent
            // 
            this.rbChatContent.Location = new System.Drawing.Point(8, 41);
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
            this.lvShowStudent.Size = new System.Drawing.Size(637, 226);
            this.lvShowStudent.TabIndex = 20;
            this.lvShowStudent.UseCompatibleStateImageBehavior = false;
            this.lvShowStudent.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(675, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 21);
            this.tsmiFile.Text = "文件";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "打开文件";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveFileToolStripMenuItem.Text = "保存文件";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "所有文件(*.*)|*.*|Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw";
            // 
            // sfdSaveFile
            // 
            this.sfdSaveFile.DefaultExt = "xls";
            this.sfdSaveFile.FileName = "导出学生信息";
            this.sfdSaveFile.Filter = "\"所有文件(*.*)|*.*|Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.x" +
    "la;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.x" +
    "la;*.xlt;*.xlm;*.xlw\"";
            this.sfdSaveFile.RestoreDirectory = true;
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerMain";
            this.Text = "研究生复试系统服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServerMain_FormClosing);
            this.Load += new System.EventHandler(this.ServerMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvShowStudent;
        private System.Windows.Forms.RichTextBox rbChatContent;
        private System.Windows.Forms.Button btDataFromDB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;

    }
}


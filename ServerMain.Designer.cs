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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAdjustStudent = new System.Windows.Forms.Button();
            this.btDispatchTeacher = new System.Windows.Forms.Button();
            this.cbGroupNumber = new System.Windows.Forms.ComboBox();
            this.tbGroupNumber = new System.Windows.Forms.TextBox();
            this.cbStudentType = new System.Windows.Forms.ComboBox();
            this.btSeparate = new System.Windows.Forms.Button();
            this.lvShowStudent = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAdjustStudent);
            this.groupBox1.Controls.Add(this.btDispatchTeacher);
            this.groupBox1.Controls.Add(this.cbGroupNumber);
            this.groupBox1.Controls.Add(this.tbGroupNumber);
            this.groupBox1.Controls.Add(this.cbStudentType);
            this.groupBox1.Controls.Add(this.btSeparate);
            this.groupBox1.Controls.Add(this.lvShowStudent);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 359);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端连接监听";
            // 
            // btAdjustStudent
            // 
            this.btAdjustStudent.Location = new System.Drawing.Point(308, 33);
            this.btAdjustStudent.Name = "btAdjustStudent";
            this.btAdjustStudent.Size = new System.Drawing.Size(75, 23);
            this.btAdjustStudent.TabIndex = 25;
            this.btAdjustStudent.Text = "调整学生";
            this.btAdjustStudent.UseVisualStyleBackColor = true;
            this.btAdjustStudent.Visible = false;
            this.btAdjustStudent.Click += new System.EventHandler(this.btAdjustStudent_Click);
            // 
            // btDispatchTeacher
            // 
            this.btDispatchTeacher.Location = new System.Drawing.Point(389, 33);
            this.btDispatchTeacher.Name = "btDispatchTeacher";
            this.btDispatchTeacher.Size = new System.Drawing.Size(75, 23);
            this.btDispatchTeacher.TabIndex = 24;
            this.btDispatchTeacher.Text = "分配老师";
            this.btDispatchTeacher.UseVisualStyleBackColor = true;
            this.btDispatchTeacher.Visible = false;
            this.btDispatchTeacher.Click += new System.EventHandler(this.btDispatchTeacher_Click);
            // 
            // cbGroupNumber
            // 
            this.cbGroupNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupNumber.FormattingEnabled = true;
            this.cbGroupNumber.Location = new System.Drawing.Point(87, 35);
            this.cbGroupNumber.Name = "cbGroupNumber";
            this.cbGroupNumber.Size = new System.Drawing.Size(72, 20);
            this.cbGroupNumber.TabIndex = 23;
            this.cbGroupNumber.Visible = false;
            this.cbGroupNumber.SelectedIndexChanged += new System.EventHandler(this.cbGroupNumber_SelectedIndexChanged);
            // 
            // tbGroupNumber
            // 
            this.tbGroupNumber.Location = new System.Drawing.Point(165, 35);
            this.tbGroupNumber.Name = "tbGroupNumber";
            this.tbGroupNumber.Size = new System.Drawing.Size(56, 21);
            this.tbGroupNumber.TabIndex = 22;
            this.tbGroupNumber.Text = "分组数目";
            this.tbGroupNumber.Visible = false;
            this.tbGroupNumber.Enter += new System.EventHandler(this.tbGroupNumber_Enter);
            this.tbGroupNumber.Leave += new System.EventHandler(this.tbGroupNumber_Leave);
            // 
            // cbStudentType
            // 
            this.cbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentType.FormattingEnabled = true;
            this.cbStudentType.Location = new System.Drawing.Point(8, 35);
            this.cbStudentType.Name = "cbStudentType";
            this.cbStudentType.Size = new System.Drawing.Size(73, 20);
            this.cbStudentType.TabIndex = 21;
            this.cbStudentType.Visible = false;
            this.cbStudentType.SelectedIndexChanged += new System.EventHandler(this.cbStudentType_SelectedIndexChanged);
            // 
            // btSeparate
            // 
            this.btSeparate.Location = new System.Drawing.Point(227, 33);
            this.btSeparate.Name = "btSeparate";
            this.btSeparate.Size = new System.Drawing.Size(75, 23);
            this.btSeparate.TabIndex = 9;
            this.btSeparate.Text = "随机分组";
            this.btSeparate.UseVisualStyleBackColor = true;
            this.btSeparate.Visible = false;
            this.btSeparate.Click += new System.EventHandler(this.btSeparate_Click);
            // 
            // lvShowStudent
            // 
            this.lvShowStudent.GridLines = true;
            this.lvShowStudent.Location = new System.Drawing.Point(8, 66);
            this.lvShowStudent.Name = "lvShowStudent";
            this.lvShowStudent.Size = new System.Drawing.Size(637, 287);
            this.lvShowStudent.TabIndex = 20;
            this.lvShowStudent.UseCompatibleStateImageBehavior = false;
            this.lvShowStudent.View = System.Windows.Forms.View.Details;
            this.lvShowStudent.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.serverToolStripMenuItem});
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
            this.saveFileToolStripMenuItem,
            this.clearFileToolStripMenuItem});
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
            // clearFileToolStripMenuItem
            // 
            this.clearFileToolStripMenuItem.Name = "clearFileToolStripMenuItem";
            this.clearFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clearFileToolStripMenuItem.Text = "清空文件";
            this.clearFileToolStripMenuItem.Click += new System.EventHandler(this.clearFileToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openServerToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.serverToolStripMenuItem.Text = "服务器";
            // 
            // openServerToolStripMenuItem
            // 
            this.openServerToolStripMenuItem.Name = "openServerToolStripMenuItem";
            this.openServerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openServerToolStripMenuItem.Text = "开启服务器";
            this.openServerToolStripMenuItem.Click += new System.EventHandler(this.openServerToolStripMenuItem_Click);
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
            this.sfdSaveFile.Filter = "所有文件(*.*)|*.*|Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw";
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
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvShowStudent;
        private System.Windows.Forms.Button btSeparate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.ComboBox cbStudentType;
        private System.Windows.Forms.TextBox tbGroupNumber;
        private System.Windows.Forms.ComboBox cbGroupNumber;
        private System.Windows.Forms.Button btDispatchTeacher;
        private System.Windows.Forms.Button btAdjustStudent;
        private System.Windows.Forms.ToolStripMenuItem clearFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openServerToolStripMenuItem;
    }
}


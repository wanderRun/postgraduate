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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btScoreManager = new System.Windows.Forms.Button();
            this.dgvShowStudent = new System.Windows.Forms.DataGridView();
            this.btManagerTeacher = new System.Windows.Forms.Button();
            this.btAdjustStudent = new System.Windows.Forms.Button();
            this.btDispatchTeacher = new System.Windows.Forms.Button();
            this.cbGroupNumber = new System.Windows.Forms.ComboBox();
            this.cbStudentType = new System.Windows.Forms.ComboBox();
            this.btSeparate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readSchoolTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readComputerAndListenScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoadSchoolType = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadComputerAndListenScore = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowStudent)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btScoreManager);
            this.groupBox1.Controls.Add(this.dgvShowStudent);
            this.groupBox1.Controls.Add(this.btManagerTeacher);
            this.groupBox1.Controls.Add(this.btAdjustStudent);
            this.groupBox1.Controls.Add(this.btDispatchTeacher);
            this.groupBox1.Controls.Add(this.cbGroupNumber);
            this.groupBox1.Controls.Add(this.cbStudentType);
            this.groupBox1.Controls.Add(this.btSeparate);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 384);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器管理";
            // 
            // btScoreManager
            // 
            this.btScoreManager.Location = new System.Drawing.Point(487, 18);
            this.btScoreManager.Name = "btScoreManager";
            this.btScoreManager.Size = new System.Drawing.Size(75, 23);
            this.btScoreManager.TabIndex = 28;
            this.btScoreManager.Text = "修改分数";
            this.btScoreManager.UseVisualStyleBackColor = true;
            this.btScoreManager.Click += new System.EventHandler(this.btScoreManager_Click);
            // 
            // dgvShowStudent
            // 
            this.dgvShowStudent.AllowUserToAddRows = false;
            this.dgvShowStudent.AllowUserToDeleteRows = false;
            this.dgvShowStudent.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShowStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowStudent.Location = new System.Drawing.Point(6, 47);
            this.dgvShowStudent.Name = "dgvShowStudent";
            this.dgvShowStudent.RowTemplate.Height = 23;
            this.dgvShowStudent.Size = new System.Drawing.Size(639, 331);
            this.dgvShowStudent.TabIndex = 27;
            // 
            // btManagerTeacher
            // 
            this.btManagerTeacher.Location = new System.Drawing.Point(325, 18);
            this.btManagerTeacher.Name = "btManagerTeacher";
            this.btManagerTeacher.Size = new System.Drawing.Size(75, 23);
            this.btManagerTeacher.TabIndex = 26;
            this.btManagerTeacher.Text = "管理老师";
            this.btManagerTeacher.UseVisualStyleBackColor = true;
            this.btManagerTeacher.Click += new System.EventHandler(this.btManagerTeacher_Click);
            // 
            // btAdjustStudent
            // 
            this.btAdjustStudent.Location = new System.Drawing.Point(244, 18);
            this.btAdjustStudent.Name = "btAdjustStudent";
            this.btAdjustStudent.Size = new System.Drawing.Size(75, 23);
            this.btAdjustStudent.TabIndex = 25;
            this.btAdjustStudent.Text = "调整学生";
            this.btAdjustStudent.UseVisualStyleBackColor = true;
            this.btAdjustStudent.Click += new System.EventHandler(this.btAdjustStudent_Click);
            // 
            // btDispatchTeacher
            // 
            this.btDispatchTeacher.Location = new System.Drawing.Point(406, 18);
            this.btDispatchTeacher.Name = "btDispatchTeacher";
            this.btDispatchTeacher.Size = new System.Drawing.Size(75, 23);
            this.btDispatchTeacher.TabIndex = 24;
            this.btDispatchTeacher.Text = "分配老师";
            this.btDispatchTeacher.UseVisualStyleBackColor = true;
            this.btDispatchTeacher.Click += new System.EventHandler(this.btDispatchTeacher_Click);
            // 
            // cbGroupNumber
            // 
            this.cbGroupNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupNumber.FormattingEnabled = true;
            this.cbGroupNumber.Location = new System.Drawing.Point(85, 20);
            this.cbGroupNumber.Name = "cbGroupNumber";
            this.cbGroupNumber.Size = new System.Drawing.Size(72, 20);
            this.cbGroupNumber.TabIndex = 23;
            this.cbGroupNumber.SelectedIndexChanged += new System.EventHandler(this.cbGroupNumber_SelectedIndexChanged);
            // 
            // cbStudentType
            // 
            this.cbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentType.FormattingEnabled = true;
            this.cbStudentType.Location = new System.Drawing.Point(6, 20);
            this.cbStudentType.Name = "cbStudentType";
            this.cbStudentType.Size = new System.Drawing.Size(73, 20);
            this.cbStudentType.TabIndex = 21;
            this.cbStudentType.SelectedIndexChanged += new System.EventHandler(this.cbStudentType_SelectedIndexChanged);
            // 
            // btSeparate
            // 
            this.btSeparate.Location = new System.Drawing.Point(163, 18);
            this.btSeparate.Name = "btSeparate";
            this.btSeparate.Size = new System.Drawing.Size(75, 23);
            this.btSeparate.TabIndex = 9;
            this.btSeparate.Text = "随机分组";
            this.btSeparate.UseVisualStyleBackColor = true;
            this.btSeparate.Click += new System.EventHandler(this.btSeparate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.serverToolStripMenuItem,
            this.clientToolStripMenuItem});
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
            this.clearFileToolStripMenuItem,
            this.readSchoolTypeToolStripMenuItem,
            this.readComputerAndListenScoreToolStripMenuItem});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 21);
            this.tsmiFile.Text = "文件";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openFileToolStripMenuItem.Text = "打开文件";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveFileToolStripMenuItem.Text = "保存文件";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // clearFileToolStripMenuItem
            // 
            this.clearFileToolStripMenuItem.Name = "clearFileToolStripMenuItem";
            this.clearFileToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.clearFileToolStripMenuItem.Text = "清空文件";
            this.clearFileToolStripMenuItem.Click += new System.EventHandler(this.clearFileToolStripMenuItem_Click);
            // 
            // readSchoolTypeToolStripMenuItem
            // 
            this.readSchoolTypeToolStripMenuItem.Name = "readSchoolTypeToolStripMenuItem";
            this.readSchoolTypeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.readSchoolTypeToolStripMenuItem.Text = "读取学校类型配置";
            this.readSchoolTypeToolStripMenuItem.Click += new System.EventHandler(this.readSchoolTypeToolStripMenuItem_Click);
            // 
            // readComputerAndListenScoreToolStripMenuItem
            // 
            this.readComputerAndListenScoreToolStripMenuItem.Name = "readComputerAndListenScoreToolStripMenuItem";
            this.readComputerAndListenScoreToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.readComputerAndListenScoreToolStripMenuItem.Text = "读取上机和听力成绩配置";
            this.readComputerAndListenScoreToolStripMenuItem.Click += new System.EventHandler(this.readComputerAndListenScoreToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openServerToolStripMenuItem,
            this.readDatabaseToolStripMenuItem,
            this.writeDatabaseToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.serverToolStripMenuItem.Text = "服务器";
            // 
            // openServerToolStripMenuItem
            // 
            this.openServerToolStripMenuItem.Name = "openServerToolStripMenuItem";
            this.openServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openServerToolStripMenuItem.Text = "开启服务器";
            this.openServerToolStripMenuItem.Click += new System.EventHandler(this.openServerToolStripMenuItem_Click);
            // 
            // readDatabaseToolStripMenuItem
            // 
            this.readDatabaseToolStripMenuItem.Name = "readDatabaseToolStripMenuItem";
            this.readDatabaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readDatabaseToolStripMenuItem.Text = "读取数据库";
            this.readDatabaseToolStripMenuItem.Click += new System.EventHandler(this.readDatabaseToolStripMenuItem_Click);
            // 
            // writeDatabaseToolStripMenuItem
            // 
            this.writeDatabaseToolStripMenuItem.Name = "writeDatabaseToolStripMenuItem";
            this.writeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.writeDatabaseToolStripMenuItem.Text = "写入数据库";
            this.writeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.writeDatabaseToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginTeacherToolStripMenuItem,
            this.studentScoreToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.clientToolStripMenuItem.Text = "客户端";
            // 
            // loginTeacherToolStripMenuItem
            // 
            this.loginTeacherToolStripMenuItem.Name = "loginTeacherToolStripMenuItem";
            this.loginTeacherToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.loginTeacherToolStripMenuItem.Text = "教师登录";
            this.loginTeacherToolStripMenuItem.Click += new System.EventHandler(this.loginTeacherToolStripMenuItem_Click);
            // 
            // studentScoreToolStripMenuItem
            // 
            this.studentScoreToolStripMenuItem.Name = "studentScoreToolStripMenuItem";
            this.studentScoreToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.studentScoreToolStripMenuItem.Text = "学生分数";
            this.studentScoreToolStripMenuItem.Click += new System.EventHandler(this.studentScoreToolStripMenuItem_Click);
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
            // ofdLoadSchoolType
            // 
            this.ofdLoadSchoolType.Filter = "Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;" +
    "*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;" +
    "*.xlw";
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerMain";
            this.Text = "研究生复试系统服务器";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowStudent)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSeparate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.ComboBox cbStudentType;
        private System.Windows.Forms.ComboBox cbGroupNumber;
        private System.Windows.Forms.Button btDispatchTeacher;
        private System.Windows.Forms.Button btAdjustStudent;
        private System.Windows.Forms.ToolStripMenuItem clearFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openServerToolStripMenuItem;
        private System.Windows.Forms.Button btManagerTeacher;
        private System.Windows.Forms.DataGridView dgvShowStudent;
        private System.Windows.Forms.ToolStripMenuItem readSchoolTypeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoadSchoolType;
        private System.Windows.Forms.ToolStripMenuItem readComputerAndListenScoreToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoadComputerAndListenScore;
        private System.Windows.Forms.Button btScoreManager;
        private System.Windows.Forms.ToolStripMenuItem readDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentScoreToolStripMenuItem;
    }
}


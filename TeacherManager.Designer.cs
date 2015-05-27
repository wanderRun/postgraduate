namespace Server
{
    partial class TeacherManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherManager));
            this.tbTeacherId1 = new System.Windows.Forms.TextBox();
            this.tbTeacherName1 = new System.Windows.Forms.TextBox();
            this.btAddTeacher = new System.Windows.Forms.Button();
            this.tbTeacherPassword = new System.Windows.Forms.TextBox();
            this.dgvTeacherInformation = new System.Windows.Forms.DataGridView();
            this.btExcelTeacher = new System.Windows.Forms.Button();
            this.ofdLoadTeacher = new System.Windows.Forms.OpenFileDialog();
            this.btClearTeacher = new System.Windows.Forms.Button();
            this.btDeleteTeacher = new System.Windows.Forms.Button();
            this.tbTeacherName2 = new System.Windows.Forms.TextBox();
            this.tbTeacherId2 = new System.Windows.Forms.TextBox();
            this.btDatabaseTeacher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTeacherId1
            // 
            this.tbTeacherId1.Location = new System.Drawing.Point(12, 12);
            this.tbTeacherId1.Name = "tbTeacherId1";
            this.tbTeacherId1.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherId1.TabIndex = 2;
            this.tbTeacherId1.Text = "老师工号";
            this.tbTeacherId1.Enter += new System.EventHandler(this.tbTeacherId1_Enter);
            this.tbTeacherId1.Leave += new System.EventHandler(this.tbTeacherId1_Leave);
            // 
            // tbTeacherName1
            // 
            this.tbTeacherName1.Location = new System.Drawing.Point(139, 12);
            this.tbTeacherName1.Name = "tbTeacherName1";
            this.tbTeacherName1.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherName1.TabIndex = 3;
            this.tbTeacherName1.Text = "老师姓名";
            this.tbTeacherName1.Enter += new System.EventHandler(this.tbTeacherName1_Enter);
            this.tbTeacherName1.Leave += new System.EventHandler(this.tbTeacherName1_Leave);
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.Location = new System.Drawing.Point(393, 10);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(75, 23);
            this.btAddTeacher.TabIndex = 1;
            this.btAddTeacher.Text = "添加老师";
            this.btAddTeacher.UseVisualStyleBackColor = true;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click);
            // 
            // tbTeacherPassword
            // 
            this.tbTeacherPassword.Location = new System.Drawing.Point(266, 12);
            this.tbTeacherPassword.Name = "tbTeacherPassword";
            this.tbTeacherPassword.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherPassword.TabIndex = 4;
            this.tbTeacherPassword.Text = "老师密码";
            this.tbTeacherPassword.Enter += new System.EventHandler(this.tbTeacherPassword_Enter);
            this.tbTeacherPassword.Leave += new System.EventHandler(this.tbTeacherPassword_Leave);
            // 
            // dgvTeacherInformation
            // 
            this.dgvTeacherInformation.AllowUserToAddRows = false;
            this.dgvTeacherInformation.AllowUserToDeleteRows = false;
            this.dgvTeacherInformation.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTeacherInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherInformation.Location = new System.Drawing.Point(12, 66);
            this.dgvTeacherInformation.Name = "dgvTeacherInformation";
            this.dgvTeacherInformation.RowTemplate.Height = 23;
            this.dgvTeacherInformation.Size = new System.Drawing.Size(460, 233);
            this.dgvTeacherInformation.TabIndex = 37;
            // 
            // btExcelTeacher
            // 
            this.btExcelTeacher.Location = new System.Drawing.Point(93, 303);
            this.btExcelTeacher.Name = "btExcelTeacher";
            this.btExcelTeacher.Size = new System.Drawing.Size(75, 23);
            this.btExcelTeacher.TabIndex = 9;
            this.btExcelTeacher.Text = "表格导入";
            this.btExcelTeacher.UseVisualStyleBackColor = true;
            this.btExcelTeacher.Click += new System.EventHandler(this.btExcelTeacher_Click);
            // 
            // ofdLoadTeacher
            // 
            this.ofdLoadTeacher.Filter = "所有文件(*.*)|*.*|Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xl" +
    "a;*.xlt;*.xlm;*.xlw";
            // 
            // btClearTeacher
            // 
            this.btClearTeacher.Location = new System.Drawing.Point(174, 303);
            this.btClearTeacher.Name = "btClearTeacher";
            this.btClearTeacher.Size = new System.Drawing.Size(75, 23);
            this.btClearTeacher.TabIndex = 10;
            this.btClearTeacher.Text = "清空老师";
            this.btClearTeacher.UseVisualStyleBackColor = true;
            this.btClearTeacher.Click += new System.EventHandler(this.btClearTeacher_Click);
            // 
            // btDeleteTeacher
            // 
            this.btDeleteTeacher.Location = new System.Drawing.Point(393, 37);
            this.btDeleteTeacher.Name = "btDeleteTeacher";
            this.btDeleteTeacher.Size = new System.Drawing.Size(75, 23);
            this.btDeleteTeacher.TabIndex = 5;
            this.btDeleteTeacher.Text = "删除老师";
            this.btDeleteTeacher.UseVisualStyleBackColor = true;
            this.btDeleteTeacher.Click += new System.EventHandler(this.btDeleteTeacher_Click);
            // 
            // tbTeacherName2
            // 
            this.tbTeacherName2.Location = new System.Drawing.Point(139, 39);
            this.tbTeacherName2.Name = "tbTeacherName2";
            this.tbTeacherName2.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherName2.TabIndex = 7;
            this.tbTeacherName2.Text = "老师姓名";
            this.tbTeacherName2.Enter += new System.EventHandler(this.tbTeacherName2_Enter);
            this.tbTeacherName2.Leave += new System.EventHandler(this.tbTeacherName2_Leave);
            // 
            // tbTeacherId2
            // 
            this.tbTeacherId2.Location = new System.Drawing.Point(13, 39);
            this.tbTeacherId2.Name = "tbTeacherId2";
            this.tbTeacherId2.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherId2.TabIndex = 6;
            this.tbTeacherId2.Text = "老师工号";
            this.tbTeacherId2.Enter += new System.EventHandler(this.tbTeacherId2_Enter);
            this.tbTeacherId2.Leave += new System.EventHandler(this.tbTeacherId2_Leave);
            // 
            // btDatabaseTeacher
            // 
            this.btDatabaseTeacher.Location = new System.Drawing.Point(12, 303);
            this.btDatabaseTeacher.Name = "btDatabaseTeacher";
            this.btDatabaseTeacher.Size = new System.Drawing.Size(75, 23);
            this.btDatabaseTeacher.TabIndex = 38;
            this.btDatabaseTeacher.Text = "数据库导入";
            this.btDatabaseTeacher.UseVisualStyleBackColor = true;
            this.btDatabaseTeacher.Click += new System.EventHandler(this.btDatabaseTeacher_Click);
            // 
            // TeacherManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 338);
            this.Controls.Add(this.btDatabaseTeacher);
            this.Controls.Add(this.btDeleteTeacher);
            this.Controls.Add(this.tbTeacherName2);
            this.Controls.Add(this.tbTeacherId2);
            this.Controls.Add(this.btClearTeacher);
            this.Controls.Add(this.btExcelTeacher);
            this.Controls.Add(this.dgvTeacherInformation);
            this.Controls.Add(this.tbTeacherPassword);
            this.Controls.Add(this.btAddTeacher);
            this.Controls.Add(this.tbTeacherName1);
            this.Controls.Add(this.tbTeacherId1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeacherManager";
            this.Text = "老师管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTeacherId1;
        private System.Windows.Forms.TextBox tbTeacherName1;
        private System.Windows.Forms.Button btAddTeacher;
        private System.Windows.Forms.TextBox tbTeacherPassword;
        private System.Windows.Forms.DataGridView dgvTeacherInformation;
        private System.Windows.Forms.Button btExcelTeacher;
        private System.Windows.Forms.OpenFileDialog ofdLoadTeacher;
        private System.Windows.Forms.Button btClearTeacher;
        private System.Windows.Forms.Button btDeleteTeacher;
        private System.Windows.Forms.TextBox tbTeacherName2;
        private System.Windows.Forms.TextBox tbTeacherId2;
        private System.Windows.Forms.Button btDatabaseTeacher;
    }
}
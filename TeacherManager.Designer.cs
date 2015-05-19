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
            this.tbTeacherId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTeacherName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btAddTeacher = new System.Windows.Forms.Button();
            this.tbTeacherPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTeacherInformation = new System.Windows.Forms.DataGridView();
            this.btGetTeacher = new System.Windows.Forms.Button();
            this.btExcelTeacher = new System.Windows.Forms.Button();
            this.ofdLoadTeacher = new System.Windows.Forms.OpenFileDialog();
            this.btClearTeacher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTeacherId
            // 
            this.tbTeacherId.Location = new System.Drawing.Point(107, 21);
            this.tbTeacherId.Name = "tbTeacherId";
            this.tbTeacherId.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherId.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "老师工号";
            // 
            // tbTeacherName
            // 
            this.tbTeacherName.Location = new System.Drawing.Point(107, 48);
            this.tbTeacherName.Name = "tbTeacherName";
            this.tbTeacherName.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "老师姓名";
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.Location = new System.Drawing.Point(107, 102);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(121, 23);
            this.btAddTeacher.TabIndex = 34;
            this.btAddTeacher.Text = "添加老师";
            this.btAddTeacher.UseVisualStyleBackColor = true;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click);
            // 
            // tbTeacherPassword
            // 
            this.tbTeacherPassword.Location = new System.Drawing.Point(107, 75);
            this.tbTeacherPassword.Name = "tbTeacherPassword";
            this.tbTeacherPassword.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherPassword.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "老师密码";
            // 
            // dgvTeacherInformation
            // 
            this.dgvTeacherInformation.AllowUserToAddRows = false;
            this.dgvTeacherInformation.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTeacherInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherInformation.Location = new System.Drawing.Point(12, 151);
            this.dgvTeacherInformation.Name = "dgvTeacherInformation";
            this.dgvTeacherInformation.RowTemplate.Height = 23;
            this.dgvTeacherInformation.Size = new System.Drawing.Size(290, 150);
            this.dgvTeacherInformation.TabIndex = 37;
            // 
            // btGetTeacher
            // 
            this.btGetTeacher.Location = new System.Drawing.Point(13, 308);
            this.btGetTeacher.Name = "btGetTeacher";
            this.btGetTeacher.Size = new System.Drawing.Size(75, 23);
            this.btGetTeacher.TabIndex = 38;
            this.btGetTeacher.Text = "数据库导入";
            this.btGetTeacher.UseVisualStyleBackColor = true;
            this.btGetTeacher.Click += new System.EventHandler(this.btGetTeacher_Click);
            // 
            // btExcelTeacher
            // 
            this.btExcelTeacher.Location = new System.Drawing.Point(94, 308);
            this.btExcelTeacher.Name = "btExcelTeacher";
            this.btExcelTeacher.Size = new System.Drawing.Size(75, 23);
            this.btExcelTeacher.TabIndex = 39;
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
            this.btClearTeacher.Location = new System.Drawing.Point(175, 308);
            this.btClearTeacher.Name = "btClearTeacher";
            this.btClearTeacher.Size = new System.Drawing.Size(75, 23);
            this.btClearTeacher.TabIndex = 40;
            this.btClearTeacher.Text = "清空老师";
            this.btClearTeacher.UseVisualStyleBackColor = true;
            this.btClearTeacher.Click += new System.EventHandler(this.btClearTeacher_Click);
            // 
            // AddTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 351);
            this.Controls.Add(this.btClearTeacher);
            this.Controls.Add(this.btExcelTeacher);
            this.Controls.Add(this.btGetTeacher);
            this.Controls.Add(this.dgvTeacherInformation);
            this.Controls.Add(this.tbTeacherPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddTeacher);
            this.Controls.Add(this.tbTeacherName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTeacherId);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddTeacher";
            this.Text = "AddTeacher";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTeacherId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTeacherName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAddTeacher;
        private System.Windows.Forms.TextBox tbTeacherPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTeacherInformation;
        private System.Windows.Forms.Button btGetTeacher;
        private System.Windows.Forms.Button btExcelTeacher;
        private System.Windows.Forms.OpenFileDialog ofdLoadTeacher;
        private System.Windows.Forms.Button btClearTeacher;
    }
}
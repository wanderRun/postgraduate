namespace Server
{
    partial class StudentScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentScore));
            this.dgvStudentScore = new System.Windows.Forms.DataGridView();
            this.btSearchStudent = new System.Windows.Forms.Button();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.tbStudentNumber = new System.Windows.Forms.TextBox();
            this.btAllStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentScore
            // 
            this.dgvStudentScore.AllowUserToAddRows = false;
            this.dgvStudentScore.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStudentScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentScore.Location = new System.Drawing.Point(12, 39);
            this.dgvStudentScore.Name = "dgvStudentScore";
            this.dgvStudentScore.RowTemplate.Height = 23;
            this.dgvStudentScore.Size = new System.Drawing.Size(422, 186);
            this.dgvStudentScore.TabIndex = 4;
            // 
            // btSearchStudent
            // 
            this.btSearchStudent.Location = new System.Drawing.Point(266, 10);
            this.btSearchStudent.Name = "btSearchStudent";
            this.btSearchStudent.Size = new System.Drawing.Size(75, 23);
            this.btSearchStudent.TabIndex = 1;
            this.btSearchStudent.Text = "查找学生";
            this.btSearchStudent.UseVisualStyleBackColor = true;
            this.btSearchStudent.Click += new System.EventHandler(this.btSearchStudent_Click);
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(139, 12);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.Size = new System.Drawing.Size(121, 21);
            this.tbStudentName.TabIndex = 3;
            this.tbStudentName.Text = "学生姓名";
            this.tbStudentName.Enter += new System.EventHandler(this.tbStudentName_Enter);
            this.tbStudentName.Leave += new System.EventHandler(this.tbStudentName_Leave);
            // 
            // tbStudentNumber
            // 
            this.tbStudentNumber.Location = new System.Drawing.Point(12, 12);
            this.tbStudentNumber.Name = "tbStudentNumber";
            this.tbStudentNumber.Size = new System.Drawing.Size(121, 21);
            this.tbStudentNumber.TabIndex = 2;
            this.tbStudentNumber.Text = "学生编号";
            this.tbStudentNumber.Enter += new System.EventHandler(this.tbStudentNumber_Enter);
            this.tbStudentNumber.Leave += new System.EventHandler(this.tbStudentNumber_Leave);
            // 
            // btAllStudent
            // 
            this.btAllStudent.Location = new System.Drawing.Point(347, 10);
            this.btAllStudent.Name = "btAllStudent";
            this.btAllStudent.Size = new System.Drawing.Size(75, 23);
            this.btAllStudent.TabIndex = 5;
            this.btAllStudent.Text = "所有学生";
            this.btAllStudent.UseVisualStyleBackColor = true;
            this.btAllStudent.Click += new System.EventHandler(this.btAllStudent_Click);
            // 
            // StudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 237);
            this.Controls.Add(this.btAllStudent);
            this.Controls.Add(this.btSearchStudent);
            this.Controls.Add(this.tbStudentName);
            this.Controls.Add(this.tbStudentNumber);
            this.Controls.Add(this.dgvStudentScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudentScore";
            this.Text = "学生分数";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentScore;
        private System.Windows.Forms.Button btSearchStudent;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.TextBox tbStudentNumber;
        private System.Windows.Forms.Button btAllStudent;
    }
}
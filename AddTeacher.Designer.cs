namespace Server
{
    partial class AddTeacher
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
            this.SuspendLayout();
            // 
            // tbTeacherId
            // 
            this.tbTeacherId.Location = new System.Drawing.Point(90, 35);
            this.tbTeacherId.Name = "tbTeacherId";
            this.tbTeacherId.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherId.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "老师工号";
            // 
            // tbTeacherName
            // 
            this.tbTeacherName.Location = new System.Drawing.Point(90, 62);
            this.tbTeacherName.Name = "tbTeacherName";
            this.tbTeacherName.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "老师姓名";
            // 
            // btAddTeacher
            // 
            this.btAddTeacher.Location = new System.Drawing.Point(90, 116);
            this.btAddTeacher.Name = "btAddTeacher";
            this.btAddTeacher.Size = new System.Drawing.Size(121, 23);
            this.btAddTeacher.TabIndex = 34;
            this.btAddTeacher.Text = "添加老师";
            this.btAddTeacher.UseVisualStyleBackColor = true;
            this.btAddTeacher.Click += new System.EventHandler(this.btAddTeacher_Click);
            // 
            // tbTeacherPassword
            // 
            this.tbTeacherPassword.Location = new System.Drawing.Point(90, 89);
            this.tbTeacherPassword.Name = "tbTeacherPassword";
            this.tbTeacherPassword.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherPassword.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "老师密码";
            // 
            // AddTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbTeacherPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAddTeacher);
            this.Controls.Add(this.tbTeacherName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTeacherId);
            this.Controls.Add(this.label5);
            this.Name = "AddTeacher";
            this.Text = "AddTeacher";
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
    }
}
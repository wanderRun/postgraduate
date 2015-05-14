namespace Server
{
    partial class DispatchTeacher
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
            this.cbStudentType = new System.Windows.Forms.ComboBox();
            this.cbStudentGroups = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTeacherId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTeacherId = new System.Windows.Forms.TextBox();
            this.tbTeacherName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btDispatchTeacher = new System.Windows.Forms.Button();
            this.btRemoveTeacher = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTeacherName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbStudentType
            // 
            this.cbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentType.FormattingEnabled = true;
            this.cbStudentType.Location = new System.Drawing.Point(71, 33);
            this.cbStudentType.Name = "cbStudentType";
            this.cbStudentType.Size = new System.Drawing.Size(121, 20);
            this.cbStudentType.TabIndex = 0;
            this.cbStudentType.SelectedIndexChanged += new System.EventHandler(this.cbStudentType_SelectedIndexChanged);
            // 
            // cbStudentGroups
            // 
            this.cbStudentGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentGroups.FormattingEnabled = true;
            this.cbStudentGroups.Location = new System.Drawing.Point(71, 59);
            this.cbStudentGroups.Name = "cbStudentGroups";
            this.cbStudentGroups.Size = new System.Drawing.Size(121, 20);
            this.cbStudentGroups.TabIndex = 1;
            this.cbStudentGroups.SelectedIndexChanged += new System.EventHandler(this.cbStudentGroups_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "学生类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "学生分组";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "老师工号";
            // 
            // cbTeacherId
            // 
            this.cbTeacherId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeacherId.FormattingEnabled = true;
            this.cbTeacherId.Location = new System.Drawing.Point(71, 85);
            this.cbTeacherId.Name = "cbTeacherId";
            this.cbTeacherId.Size = new System.Drawing.Size(121, 20);
            this.cbTeacherId.TabIndex = 4;
            this.cbTeacherId.SelectedIndexChanged += new System.EventHandler(this.cbTeacherId_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "分配工号";
            // 
            // tbTeacherId
            // 
            this.tbTeacherId.Location = new System.Drawing.Point(71, 137);
            this.tbTeacherId.Name = "tbTeacherId";
            this.tbTeacherId.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherId.TabIndex = 26;
            // 
            // tbTeacherName
            // 
            this.tbTeacherName.Location = new System.Drawing.Point(71, 164);
            this.tbTeacherName.Name = "tbTeacherName";
            this.tbTeacherName.Size = new System.Drawing.Size(121, 21);
            this.tbTeacherName.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "分配姓名";
            // 
            // btDispatchTeacher
            // 
            this.btDispatchTeacher.Location = new System.Drawing.Point(14, 191);
            this.btDispatchTeacher.Name = "btDispatchTeacher";
            this.btDispatchTeacher.Size = new System.Drawing.Size(75, 23);
            this.btDispatchTeacher.TabIndex = 29;
            this.btDispatchTeacher.Text = "分配老师";
            this.btDispatchTeacher.UseVisualStyleBackColor = true;
            this.btDispatchTeacher.Click += new System.EventHandler(this.btDispatchTeacher_Click);
            // 
            // btRemoveTeacher
            // 
            this.btRemoveTeacher.Location = new System.Drawing.Point(117, 191);
            this.btRemoveTeacher.Name = "btRemoveTeacher";
            this.btRemoveTeacher.Size = new System.Drawing.Size(75, 23);
            this.btRemoveTeacher.TabIndex = 30;
            this.btRemoveTeacher.Text = "移除老师";
            this.btRemoveTeacher.UseVisualStyleBackColor = true;
            this.btRemoveTeacher.Click += new System.EventHandler(this.btRemoveTeacher_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "老师姓名";
            // 
            // cbTeacherName
            // 
            this.cbTeacherName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeacherName.FormattingEnabled = true;
            this.cbTeacherName.Location = new System.Drawing.Point(71, 111);
            this.cbTeacherName.Name = "cbTeacherName";
            this.cbTeacherName.Size = new System.Drawing.Size(121, 20);
            this.cbTeacherName.TabIndex = 31;
            this.cbTeacherName.SelectedIndexChanged += new System.EventHandler(this.cbTeacherName_SelectedIndexChanged);
            // 
            // DispatchTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 270);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTeacherName);
            this.Controls.Add(this.btRemoveTeacher);
            this.Controls.Add(this.btDispatchTeacher);
            this.Controls.Add(this.tbTeacherName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTeacherId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTeacherId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStudentType);
            this.Controls.Add(this.cbStudentGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DispatchTeacher";
            this.Text = "分配老师";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStudentType;
        private System.Windows.Forms.ComboBox cbStudentGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTeacherId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTeacherId;
        private System.Windows.Forms.TextBox tbTeacherName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btDispatchTeacher;
        private System.Windows.Forms.Button btRemoveTeacher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTeacherName;
    }
}
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
            this.label5 = new System.Windows.Forms.Label();
            this.btDispatchTeacher = new System.Windows.Forms.Button();
            this.btRemoveTeacher = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTeacherName = new System.Windows.Forms.ComboBox();
            this.cbAssignId = new System.Windows.Forms.ComboBox();
            this.cbAssignName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbStudentType
            // 
            this.cbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentType.FormattingEnabled = true;
            this.cbStudentType.Location = new System.Drawing.Point(91, 12);
            this.cbStudentType.Name = "cbStudentType";
            this.cbStudentType.Size = new System.Drawing.Size(121, 20);
            this.cbStudentType.TabIndex = 0;
            this.cbStudentType.SelectedIndexChanged += new System.EventHandler(this.cbStudentType_SelectedIndexChanged);
            // 
            // cbStudentGroups
            // 
            this.cbStudentGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentGroups.FormattingEnabled = true;
            this.cbStudentGroups.Location = new System.Drawing.Point(91, 38);
            this.cbStudentGroups.Name = "cbStudentGroups";
            this.cbStudentGroups.Size = new System.Drawing.Size(121, 20);
            this.cbStudentGroups.TabIndex = 1;
            this.cbStudentGroups.SelectedIndexChanged += new System.EventHandler(this.cbStudentGroups_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "学生类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "学生分组";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "老师工号";
            // 
            // cbTeacherId
            // 
            this.cbTeacherId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeacherId.FormattingEnabled = true;
            this.cbTeacherId.Location = new System.Drawing.Point(79, 20);
            this.cbTeacherId.Name = "cbTeacherId";
            this.cbTeacherId.Size = new System.Drawing.Size(121, 20);
            this.cbTeacherId.TabIndex = 4;
            this.cbTeacherId.SelectedIndexChanged += new System.EventHandler(this.cbTeacherId_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "分配工号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "分配姓名";
            // 
            // btDispatchTeacher
            // 
            this.btDispatchTeacher.Location = new System.Drawing.Point(79, 74);
            this.btDispatchTeacher.Name = "btDispatchTeacher";
            this.btDispatchTeacher.Size = new System.Drawing.Size(121, 23);
            this.btDispatchTeacher.TabIndex = 29;
            this.btDispatchTeacher.Text = "分配老师";
            this.btDispatchTeacher.UseVisualStyleBackColor = true;
            this.btDispatchTeacher.Click += new System.EventHandler(this.btDispatchTeacher_Click);
            // 
            // btRemoveTeacher
            // 
            this.btRemoveTeacher.Location = new System.Drawing.Point(79, 72);
            this.btRemoveTeacher.Name = "btRemoveTeacher";
            this.btRemoveTeacher.Size = new System.Drawing.Size(121, 23);
            this.btRemoveTeacher.TabIndex = 30;
            this.btRemoveTeacher.Text = "移除老师";
            this.btRemoveTeacher.UseVisualStyleBackColor = true;
            this.btRemoveTeacher.Click += new System.EventHandler(this.btRemoveTeacher_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "老师姓名";
            // 
            // cbTeacherName
            // 
            this.cbTeacherName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeacherName.FormattingEnabled = true;
            this.cbTeacherName.Location = new System.Drawing.Point(79, 46);
            this.cbTeacherName.Name = "cbTeacherName";
            this.cbTeacherName.Size = new System.Drawing.Size(121, 20);
            this.cbTeacherName.TabIndex = 31;
            this.cbTeacherName.SelectedIndexChanged += new System.EventHandler(this.cbTeacherName_SelectedIndexChanged);
            // 
            // cbAssignId
            // 
            this.cbAssignId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignId.FormattingEnabled = true;
            this.cbAssignId.Location = new System.Drawing.Point(79, 20);
            this.cbAssignId.Name = "cbAssignId";
            this.cbAssignId.Size = new System.Drawing.Size(121, 20);
            this.cbAssignId.TabIndex = 33;
            this.cbAssignId.SelectedIndexChanged += new System.EventHandler(this.cbAssignId_SelectedIndexChanged);
            // 
            // cbAssignName
            // 
            this.cbAssignName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignName.FormattingEnabled = true;
            this.cbAssignName.Location = new System.Drawing.Point(79, 46);
            this.cbAssignName.Name = "cbAssignName";
            this.cbAssignName.Size = new System.Drawing.Size(121, 20);
            this.cbAssignName.TabIndex = 34;
            this.cbAssignName.SelectedIndexChanged += new System.EventHandler(this.cbAssignName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTeacherId);
            this.groupBox1.Controls.Add(this.btRemoveTeacher);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbTeacherName);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移除老师";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAssignId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbAssignName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btDispatchTeacher);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 100);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分配老师";
            // 
            // DispatchTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStudentType);
            this.Controls.Add(this.cbStudentGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DispatchTeacher";
            this.Text = "分配老师";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btDispatchTeacher;
        private System.Windows.Forms.Button btRemoveTeacher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTeacherName;
        private System.Windows.Forms.ComboBox cbAssignId;
        private System.Windows.Forms.ComboBox cbAssignName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
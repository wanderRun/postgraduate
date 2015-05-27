namespace Server
{
    partial class AdjustStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustStudent));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStudentType = new System.Windows.Forms.ComboBox();
            this.cbStudentGroups = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStudentNumber = new System.Windows.Forms.ComboBox();
            this.cbStudentName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAdjustGroups = new System.Windows.Forms.ComboBox();
            this.btAdjustStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "学生分组";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "学生类型";
            // 
            // cbStudentType
            // 
            this.cbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentType.FormattingEnabled = true;
            this.cbStudentType.Location = new System.Drawing.Point(79, 21);
            this.cbStudentType.Name = "cbStudentType";
            this.cbStudentType.Size = new System.Drawing.Size(121, 20);
            this.cbStudentType.TabIndex = 4;
            this.cbStudentType.SelectedIndexChanged += new System.EventHandler(this.cbStudentType_SelectedIndexChanged);
            // 
            // cbStudentGroups
            // 
            this.cbStudentGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentGroups.FormattingEnabled = true;
            this.cbStudentGroups.Location = new System.Drawing.Point(79, 47);
            this.cbStudentGroups.Name = "cbStudentGroups";
            this.cbStudentGroups.Size = new System.Drawing.Size(121, 20);
            this.cbStudentGroups.TabIndex = 5;
            this.cbStudentGroups.SelectedIndexChanged += new System.EventHandler(this.cbStudentGroups_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "学生姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "学生编号";
            // 
            // cbStudentNumber
            // 
            this.cbStudentNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentNumber.FormattingEnabled = true;
            this.cbStudentNumber.Location = new System.Drawing.Point(79, 73);
            this.cbStudentNumber.Name = "cbStudentNumber";
            this.cbStudentNumber.Size = new System.Drawing.Size(121, 20);
            this.cbStudentNumber.TabIndex = 8;
            this.cbStudentNumber.SelectedIndexChanged += new System.EventHandler(this.cbStudentNumber_SelectedIndexChanged);
            // 
            // cbStudentName
            // 
            this.cbStudentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentName.FormattingEnabled = true;
            this.cbStudentName.Location = new System.Drawing.Point(79, 99);
            this.cbStudentName.Name = "cbStudentName";
            this.cbStudentName.Size = new System.Drawing.Size(121, 20);
            this.cbStudentName.TabIndex = 9;
            this.cbStudentName.SelectedIndexChanged += new System.EventHandler(this.cbStudentName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "调整分组";
            // 
            // cbAdjustGroups
            // 
            this.cbAdjustGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdjustGroups.FormattingEnabled = true;
            this.cbAdjustGroups.Location = new System.Drawing.Point(79, 125);
            this.cbAdjustGroups.Name = "cbAdjustGroups";
            this.cbAdjustGroups.Size = new System.Drawing.Size(121, 20);
            this.cbAdjustGroups.TabIndex = 12;
            // 
            // btAdjustStudent
            // 
            this.btAdjustStudent.Location = new System.Drawing.Point(79, 151);
            this.btAdjustStudent.Name = "btAdjustStudent";
            this.btAdjustStudent.Size = new System.Drawing.Size(121, 23);
            this.btAdjustStudent.TabIndex = 14;
            this.btAdjustStudent.Text = "调整学生分组";
            this.btAdjustStudent.UseVisualStyleBackColor = true;
            this.btAdjustStudent.Click += new System.EventHandler(this.btAdjustStudent_Click);
            // 
            // AdjustStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 200);
            this.Controls.Add(this.btAdjustStudent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbAdjustGroups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStudentNumber);
            this.Controls.Add(this.cbStudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStudentType);
            this.Controls.Add(this.cbStudentGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdjustStudent";
            this.Text = "调整学生";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStudentType;
        private System.Windows.Forms.ComboBox cbStudentGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbStudentNumber;
        private System.Windows.Forms.ComboBox cbStudentName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAdjustGroups;
        private System.Windows.Forms.Button btAdjustStudent;
    }
}
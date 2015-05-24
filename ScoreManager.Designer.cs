namespace Server
{
    partial class ScoreManager
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
            this.dgvStudentScore = new System.Windows.Forms.DataGridView();
            this.tbStudentNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentScore
            // 
            this.dgvStudentScore.AllowUserToAddRows = false;
            this.dgvStudentScore.AllowUserToDeleteRows = false;
            this.dgvStudentScore.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStudentScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentScore.Location = new System.Drawing.Point(12, 39);
            this.dgvStudentScore.Name = "dgvStudentScore";
            this.dgvStudentScore.RowTemplate.Height = 23;
            this.dgvStudentScore.Size = new System.Drawing.Size(449, 247);
            this.dgvStudentScore.TabIndex = 0;
            // 
            // tbStudentNumber
            // 
            this.tbStudentNumber.Location = new System.Drawing.Point(12, 12);
            this.tbStudentNumber.Name = "tbStudentNumber";
            this.tbStudentNumber.Size = new System.Drawing.Size(121, 21);
            this.tbStudentNumber.TabIndex = 38;
            this.tbStudentNumber.Text = "学生编号";
            this.tbStudentNumber.Enter += new System.EventHandler(this.tbStudentNumber_Enter);
            this.tbStudentNumber.Leave += new System.EventHandler(this.tbStudentNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 37;
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(139, 12);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.Size = new System.Drawing.Size(121, 21);
            this.tbStudentName.TabIndex = 40;
            this.tbStudentName.Text = "学生姓名";
            this.tbStudentName.Enter += new System.EventHandler(this.tbStudentName_Enter);
            this.tbStudentName.Leave += new System.EventHandler(this.tbStudentName_Leave);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(266, 10);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 41;
            this.btSearch.Text = "查找";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(347, 10);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 42;
            this.btClear.Text = "全部学生";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // ScoreManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 308);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbStudentName);
            this.Controls.Add(this.tbStudentNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvStudentScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ScoreManager";
            this.Text = "学生分数管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentScore;
        private System.Windows.Forms.TextBox tbStudentNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btClear;
    }
}
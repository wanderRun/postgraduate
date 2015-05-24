namespace Server
{
    partial class TeacherLogin
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
            this.lvTeacherLogin = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvTeacherLogin
            // 
            this.lvTeacherLogin.Location = new System.Drawing.Point(12, 12);
            this.lvTeacherLogin.Name = "lvTeacherLogin";
            this.lvTeacherLogin.Size = new System.Drawing.Size(164, 238);
            this.lvTeacherLogin.TabIndex = 1;
            this.lvTeacherLogin.UseCompatibleStateImageBehavior = false;
            this.lvTeacherLogin.View = System.Windows.Forms.View.Details;
            // 
            // TeacherLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 262);
            this.Controls.Add(this.lvTeacherLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TeacherLogin";
            this.Text = "教师登录";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvTeacherLogin;
    }
}
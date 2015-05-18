using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            if (tbTeacherPassword.Text == "")
            {
                DataManager.AddTeacher(tbTeacherId.Text, tbTeacherName.Text);
            }
            else
            {
                DataManager.AddTeacher(tbTeacherId.Text, tbTeacherName.Text, tbTeacherPassword.Text);
            }
            MessageBox.Show("添加老师完成");
        }
    }
}

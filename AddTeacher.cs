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

        private void btGetTeacher_Click(object sender, EventArgs e)
        {
            dgvTeacherInformation.Columns.Clear();
            //dgvTeacherInformation.Rows.Clear();
            dgvTeacherInformation.Columns.Add("teacherId", "老师工号");
            dgvTeacherInformation.Columns.Add("teacherName", "老师姓名");
            dgvTeacherInformation.Columns.Add("teacherPassword", "老师密码");
            DataTable dataTable = MysqlManager.SelectData("teacher_information");
            DataManager.LoadTeacherFromSQL(dataTable);
            for (int i = 0; i < DataManager.Teachers.teacher.Count; ++i)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].id;
                dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].name;
                dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].password;
                dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                dgvTeacherInformation.Rows.Add(dataGridViewRow);
            }
        }

        private void btExcelTeacher_Click(object sender, EventArgs e)
        {
            if (ofdLoadTeacher.ShowDialog() == DialogResult.OK)
            {
                DataManager.LoadTeacherFromExcel(ofdLoadTeacher.FileName);
                dgvTeacherInformation.Columns.Clear();
                dgvTeacherInformation.Columns.Add("teacherId", "老师工号");
                dgvTeacherInformation.Columns.Add("teacherName", "老师姓名");
                dgvTeacherInformation.Columns.Add("teacherPassword", "老师密码");
                for (int i = 0; i < DataManager.Teachers.teacher.Count; ++i)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                    dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].id;
                    dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                    dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                    dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].name;
                    dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                    dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
                    dataGridViewTextBoxCell.Value = DataManager.Teachers.teacher[i].password;
                    dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
                    dgvTeacherInformation.Rows.Add(dataGridViewRow);
                }
            }
        }

        private void btClearTeacher_Click(object sender, EventArgs e)
        {
            dgvTeacherInformation.Columns.Clear();
            DataManager.ClearTeacher();
        }
    }
}

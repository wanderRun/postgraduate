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
    public partial class TeacherManager : Form
    {
        public TeacherManager()
        {
            InitializeComponent();
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            if (tbTeacherId1.Text == "老师工号" && tbTeacherName1.Text == "老师姓名")
            {
                MessageBox.Show("老师信息不能为空");
                return;
            }
            if (tbTeacherPassword.Text == "老师密码")
            {
                DataManager.AddTeacher(tbTeacherId1.Text, tbTeacherName1.Text);
            }
            else
            {
                DataManager.AddTeacher(tbTeacherId1.Text, tbTeacherName1.Text, tbTeacherPassword.Text);
            }
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
            tbTeacherId1.Text = "老师工号";
            tbTeacherName1.Text = "老师姓名";
            tbTeacherPassword.Text = "老师密码";
            MessageBox.Show("添加老师完成");
        }

        private void btGetTeacher_Click(object sender, EventArgs e)
        {
            dgvTeacherInformation.Columns.Clear();
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
                MessageBox.Show("老师导入完成");
            }
        }

        private void btClearTeacher_Click(object sender, EventArgs e)
        {
            dgvTeacherInformation.Columns.Clear();
            DataManager.ClearTeacher();
        }

        private void tbTeacherId1_Enter(object sender, EventArgs e)
        {
            if(tbTeacherId1.Text == "老师工号")
            {
                tbTeacherId1.Text = "";
            }
        }

        private void tbTeacherId1_Leave(object sender, EventArgs e)
        {
            if (tbTeacherId1.Text == "")
            {
                tbTeacherId1.Text = "老师工号";
            }
        }

        private void tbTeacherName1_Enter(object sender, EventArgs e)
        {
            if (tbTeacherName1.Text == "老师姓名")
            {
                tbTeacherName1.Text = "";
            }
        }

        private void tbTeacherName1_Leave(object sender, EventArgs e)
        {
            if (tbTeacherName1.Text == "")
            {
                tbTeacherName1.Text = "老师姓名";
            }
        }

        private void tbTeacherPassword_Enter(object sender, EventArgs e)
        {
            if (tbTeacherPassword.Text == "老师密码")
            {
                tbTeacherPassword.Text = "";
            }
        }

        private void tbTeacherPassword_Leave(object sender, EventArgs e)
        {
            if (tbTeacherPassword.Text == "")
            {
                tbTeacherPassword.Text = "老师密码";
            }
        }

        private void tbTeacherId2_Enter(object sender, EventArgs e)
        {
            if (tbTeacherId2.Text == "老师工号")
            {
                tbTeacherId2.Text = "";
            }
        }

        private void tbTeacherId2_Leave(object sender, EventArgs e)
        {
            if (tbTeacherId2.Text == "")
            {
                tbTeacherId2.Text = "老师工号";
            }
        }

        private void tbTeacherName2_Enter(object sender, EventArgs e)
        {
            if (tbTeacherName2.Text == "老师姓名")
            {
                tbTeacherName2.Text = "";
            }
        }

        private void tbTeacherName2_Leave(object sender, EventArgs e)
        {
            if (tbTeacherName2.Text == "")
            {
                tbTeacherName2.Text = "老师姓名";
            }
        }

        private void btDeleteTeacher_Click(object sender, EventArgs e)
        {
            if(tbTeacherId2.Text == "老师工号" && tbTeacherName2.Text == "老师姓名")
            {
                MessageBox.Show("找不到老师信息");
                return;
            }
            int index = 0;
            int number = 0;
            List<message.TeacherInfo> teacherInfo;
            index = DataManager.Teachers.teacher.FindIndex(t => t.id == tbTeacherId2.Text);
            if(index != -1)
            {
                number = DataManager.RemoveTeacherByIndex(index);
            }
            else
            {
                teacherInfo = DataManager.Teachers.teacher.FindAll(t => t.name == tbTeacherName2.Text);
                if(teacherInfo.Count == 0)
                {
                    MessageBox.Show("找不到老师信息");
                    return;
                }
                number = DataManager.RemoveTeacherByName(tbTeacherName2.Text);
            }
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
            tbTeacherId2.Text = "老师工号";
            tbTeacherName2.Text = "老师姓名";
            MessageBox.Show("一共删除老师" + number + "个");
        }
    }
}

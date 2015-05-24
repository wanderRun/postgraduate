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
    public partial class StudentScore : Form
    {
        public StudentScore()
        {
            InitializeComponent();
            this.ShowStudentScore(DataManager.Students);
        }

        private void tbStudentNumber_Enter(object sender, EventArgs e)
        {
            if(tbStudentNumber.Text == "学生编号")
            {
                tbStudentNumber.Text = "";
            }
        }

        private void tbStudentNumber_Leave(object sender, EventArgs e)
        {
            if (tbStudentNumber.Text == "")
            {
                tbStudentNumber.Text = "学生编号";
            }
        }

        private void tbStudentName_Enter(object sender, EventArgs e)
        {
            if (tbStudentName.Text == "学生姓名")
            {
                tbStudentName.Text = "";
            }
        }

        private void tbStudentName_Leave(object sender, EventArgs e)
        {
            if (tbStudentName.Text == "")
            {
                tbStudentName.Text = "学生姓名";
            }
        }

        private void btSearchStudent_Click(object sender, EventArgs e)
        {
            if(tbStudentName.Text == "学生姓名" && tbStudentNumber.Text == "学生编号")
            {
                MessageBox.Show("学生姓名或者学生编号不能为空");
                return;
            }
            List<message.StudentInfo> studentInfo;
            studentInfo = DataManager.Students.student.FindAll(s => s.number == tbStudentNumber.Text);
            if (studentInfo.Count == 0)
            {
                studentInfo = DataManager.Students.student.FindAll(s => s.name == tbStudentName.Text);
                if(studentInfo.Count == 0)
                {
                    MessageBox.Show("查找不到学生编号为" + tbStudentNumber.Text + "或者学生姓名为" + tbStudentName.Text + "的学生");
                    return;
                }
            }
            message.Students students = new message.Students();
            foreach(message.StudentInfo student in studentInfo)
            {
                students.student.Add(student);
            }
            this.ShowStudentScore(students);
        }

        private void btAllStudent_Click(object sender, EventArgs e)
        {
            this.ShowStudentScore(DataManager.Students);
        }

        private void ShowStudentScore(message.Students students)
        {
            dgvStudentScore.Columns.Clear();
            dgvStudentScore.Columns.Add("name", "学生姓名");
            dgvStudentScore.Columns.Add("total_score", "初试总分");
            dgvStudentScore.Columns.Add("operation", "上机成绩");
            dgvStudentScore.Columns.Add("hear", "听力");
            dgvStudentScore.Columns.Add("school_score", "本科院校 985或211院校30分 省重点院校20分 其他10分");
            dgvStudentScore.Columns.Add("introduction_score", "自我介绍（本科阶段综合表现与申请材料）10分");
            dgvStudentScore.Columns.Add("translation_score", "翻译10分");
            dgvStudentScore.Columns.Add("topic_score", "TOPIC20分");
            dgvStudentScore.Columns.Add("answer_score", "回答提问30分");
            dgvStudentScore.Columns.Add("result_score", "面试(总评分)");
            foreach(message.StudentInfo studentInfo in students.student)
            {
                int index = dgvStudentScore.Rows.Add();
                dgvStudentScore.Rows[index].Cells["name"].Value = studentInfo.name;
                dgvStudentScore.Rows[index].Cells["total_score"].Value = studentInfo.total_score;
                dgvStudentScore.Rows[index].Cells["operation"].Value = studentInfo.operation;
                dgvStudentScore.Rows[index].Cells["hear"].Value = studentInfo.hear;
                dgvStudentScore.Rows[index].Cells["school_score"].Value = studentInfo.school_score;
                dgvStudentScore.Rows[index].Cells["introduction_score"].Value = studentInfo.introduction_score;
                dgvStudentScore.Rows[index].Cells["translation_score"].Value = studentInfo.translation_score;
                dgvStudentScore.Rows[index].Cells["topic_score"].Value = studentInfo.topic_score;
                dgvStudentScore.Rows[index].Cells["answer_score"].Value = studentInfo.answer_score;
                dgvStudentScore.Rows[index].Cells["result_score"].Value = studentInfo.result_score;
            }
        }
    }
}

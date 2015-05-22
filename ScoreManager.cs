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
    public partial class ScoreManager : Form
    {
        public ScoreManager()
        {
            InitializeComponent();
            this.btClear_Click(null, null);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if(tbStudentNumber.Text == "" && tbStudentName.Text == "")
            {
                MessageBox.Show("学生编号或者学生姓名有一个不能为空");
                return;
            }
            dgvStudentScore.Columns.Clear();
            dgvStudentScore.Columns.Add("number", "考生编号");
            dgvStudentScore.Columns.Add("name", "考生姓名");
            dgvStudentScore.Columns.Add("school_score", "本科院校 985或211院校30分 省重点院校20分 其他10分");
            dgvStudentScore.Columns.Add("introduction_score", "自我介绍（本科阶段综合表现与申请材料）10分");
            dgvStudentScore.Columns.Add("translation_score", "翻译10分");
            dgvStudentScore.Columns.Add("topic_score", "TOPIC20分");
            dgvStudentScore.Columns.Add("answer_score", "回答提问30分");
            dgvStudentScore.Columns.Add("result_score", "面试(总评分)");
            int index = 0;
            List<message.StudentInfo> studentInfo;
            if (tbStudentNumber.Text != "学生编号")
            {
                index = DataManager.Students.student.FindIndex(s => s.number == tbStudentNumber.Text);
                if(index == -1)
                {
                    MessageBox.Show("查找不到学生编号为" +　tbStudentNumber.Text + "的学生");
                    return;
                }
                int number = dgvStudentScore.Rows.Add();
                dgvStudentScore.Rows[number].Cells["number"].Value = DataManager.Students.student[index].number;
                dgvStudentScore.Rows[number].Cells["name"].Value = DataManager.Students.student[index].name;
                dgvStudentScore.Rows[number].Cells["school_score"].Value = DataManager.Students.student[index].school_score;
                dgvStudentScore.Rows[number].Cells["introduction_score"].Value = DataManager.Students.student[index].introduction_score;
                dgvStudentScore.Rows[number].Cells["translation_score"].Value = DataManager.Students.student[index].translation_score;
                dgvStudentScore.Rows[number].Cells["topic_score"].Value = DataManager.Students.student[index].topic_score;
                dgvStudentScore.Rows[number].Cells["answer_score"].Value = DataManager.Students.student[index].answer_score;
                dgvStudentScore.Rows[number].Cells["result_score"].Value = DataManager.Students.student[index].result_score;
            }
            else
            {
                studentInfo = DataManager.Students.student.FindAll(s => s.name == tbStudentName.Text);
                if(studentInfo.Count == 0)
                {
                    MessageBox.Show("查找不到学生姓名为" +　tbStudentName.Text + "的学生");
                    return;
                }
                foreach(message.StudentInfo student in studentInfo)
                {
                    int number = dgvStudentScore.Rows.Add();
                    dgvStudentScore.Rows[number].Cells["number"].Value = DataManager.Students.student[index].number;
                    dgvStudentScore.Rows[number].Cells["name"].Value = DataManager.Students.student[index].name;
                    dgvStudentScore.Rows[number].Cells["school_score"].Value = DataManager.Students.student[index].school_score;
                    dgvStudentScore.Rows[number].Cells["introduction_score"].Value = DataManager.Students.student[index].introduction_score;
                    dgvStudentScore.Rows[number].Cells["translation_score"].Value = DataManager.Students.student[index].translation_score;
                    dgvStudentScore.Rows[number].Cells["topic_score"].Value = DataManager.Students.student[index].topic_score;
                    dgvStudentScore.Rows[number].Cells["answer_score"].Value = DataManager.Students.student[index].answer_score;
                    dgvStudentScore.Rows[number].Cells["result_score"].Value = DataManager.Students.student[index].result_score;
                }
            }
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
                tbStudentNumber.Text = "";
            }
        }

        private void tbStudentName_Leave(object sender, EventArgs e)
        {
            if (tbStudentName.Text == "")
            {
                tbStudentNumber.Text = "学生姓名";
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            dgvStudentScore.Columns.Clear();
            dgvStudentScore.Columns.Add("number", "考生编号");
            dgvStudentScore.Columns.Add("name", "考生姓名");
            dgvStudentScore.Columns.Add("school_score", "本科院校 985或211院校30分 省重点院校20分 其他10分");
            dgvStudentScore.Columns.Add("introduction_score", "自我介绍（本科阶段综合表现与申请材料）10分");
            dgvStudentScore.Columns.Add("translation_score", "翻译10分");
            dgvStudentScore.Columns.Add("topic_score", "TOPIC20分");
            dgvStudentScore.Columns.Add("answer_score", "回答提问30分");
            dgvStudentScore.Columns.Add("result_score", "面试(总评分)");
            foreach(message.StudentInfo student in DataManager.Students.student)
            {
                int number = dgvStudentScore.Rows.Add();
                dgvStudentScore.Rows[number].Cells["number"].Value = student.number;
                dgvStudentScore.Rows[number].Cells["name"].Value = student.name;
                dgvStudentScore.Rows[number].Cells["school_score"].Value = student.school_score;
                dgvStudentScore.Rows[number].Cells["introduction_score"].Value = student.introduction_score;
                dgvStudentScore.Rows[number].Cells["translation_score"].Value = student.translation_score;
                dgvStudentScore.Rows[number].Cells["topic_score"].Value = student.topic_score;
                dgvStudentScore.Rows[number].Cells["answer_score"].Value = student.answer_score;
                dgvStudentScore.Rows[number].Cells["result_score"].Value = student.result_score;
            }
        }
    }
}

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
    public partial class DispatchTeacher : Form
    {
        public DispatchTeacher()
        {
            InitializeComponent();
            cbStudentType.Items.Add("全部类型");
            cbStudentType.Items.Add("专业硕士");
            cbStudentType.Items.Add("学术硕士");
            cbStudentType.SelectedIndex = 0;
        }

        private void cbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStudentType.SelectedIndex == 0)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbStudentGroups.SelectedIndex = 0;
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                cbTeacherId.SelectedIndex = 0;
            }
            else if(cbStudentType.SelectedIndex == 1)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                for(int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                cbTeacherId.SelectedIndex = 0;
            }
            else if(cbStudentType.SelectedIndex == 2)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                for(int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                cbTeacherId.SelectedIndex = 0;
            }
        }

        private void btDispatchTeacher_Click(object sender, EventArgs e)
        {
            if(cbStudentType.SelectedIndex == 0)
            {
                MessageBox.Show("学生类型为全部学生无法分配老师");
                return;
            }
            if(cbStudentGroups.SelectedIndex == 0)
            {
                MessageBox.Show("学生分组为全部学生无法分配老师");
                return;
            }
            if(tbTeacherId.Text.Equals(""))
            {
                MessageBox.Show("老师工号为空无法分配老师");
                return;
            }
            if(tbTeacherName.Text.Equals(""))
            {
                MessageBox.Show("老师姓名为空无法分配老师");
                return;
            }
            DataManager.DispatchTeacher(cbStudentType.SelectedIndex, cbStudentGroups.SelectedIndex - 1, tbTeacherId.Text, tbTeacherName.Text);
            if (cbStudentType.SelectedIndex == 1)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for (int i = 0; i < DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for (int i = 0; i < DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            cbTeacherId.SelectedIndex = 0;
            tbTeacherId.Text = "";
            tbTeacherName.Text = "";
        }

        private void cbStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStudentGroups.SelectedIndex == 0)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                cbTeacherId.SelectedIndex = 0;
                return;
            }
            if(cbStudentType.SelectedIndex == 1)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for(int i = 0; i < DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            else if(cbStudentType.SelectedIndex == 2)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for (int i = 0; i < DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            cbTeacherId.SelectedIndex = 0;
        }

        private void btRemoveTeacher_Click(object sender, EventArgs e)
        {
            if(cbTeacherId.SelectedIndex == 0)
            {
                MessageBox.Show("选择的老师为空");
                return;
            }
            DataManager.RemoveTeacher(cbStudentType.SelectedIndex, cbStudentGroups.SelectedIndex - 1, cbTeacherId.Text);
            if (cbStudentType.SelectedIndex == 1)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for (int i = 0; i < DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbTeacherId.Items.Clear();
                cbTeacherId.Items.Add("全部老师");
                cbTeacherName.Items.Clear();
                cbTeacherName.Items.Add("全部老师");
                for (int i = 0; i < DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id.Count; ++i)
                {
                    cbTeacherId.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_id[i]);
                    cbTeacherName.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][0].teacher_name[i]);
                }
            }
            cbTeacherId.SelectedIndex = 0;
        }

        private void cbTeacherId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTeacherName.SelectedIndex = cbTeacherId.SelectedIndex;
        }

        private void cbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTeacherId.SelectedIndex = cbTeacherName.SelectedIndex;
        }
    }
}

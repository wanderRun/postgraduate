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
    public partial class AdjustStudent : Form
    {
        public AdjustStudent()
        {
            InitializeComponent();
            cbStudentType.Items.Add("全部类型");
            cbStudentType.Items.Add("专业硕士");
            cbStudentType.Items.Add("学术硕士");
            cbStudentType.SelectedIndex = 0;
        }

        private void cbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudentType.SelectedIndex == 0)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbStudentGroups.SelectedIndex = 0;
            }
            else if (cbStudentType.SelectedIndex == 1)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbAdjustGroups.Items.Clear();
                for (int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                    cbAdjustGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbAdjustGroups.Items.Clear();
                for (int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                    cbAdjustGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
            }
        }

        private void cbStudentNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbStudentName.SelectedIndex = cbStudentNumber.SelectedIndex;
        }

        private void cbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbStudentNumber.SelectedIndex = cbStudentName.SelectedIndex;
        }

        private void cbStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStudentGroups.SelectedIndex < 0)
            {
                return;
            }
            if(cbStudentGroups.SelectedIndex == 0)
            {
                cbStudentNumber.Items.Clear();
                cbStudentNumber.Items.Add("全部学生");
                cbStudentName.Items.Clear();
                cbStudentName.Items.Add("全部学生");
                cbStudentNumber.SelectedIndex = 0;
                return;
            }
            if(cbStudentType.SelectedIndex == 1)
            {
                cbStudentNumber.Items.Clear();
                cbStudentNumber.Items.Add("全部学生");
                cbStudentName.Items.Clear();
                cbStudentName.Items.Add("全部学生");
                for(int i = 0; i < DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1].Count; ++i)
                {
                    cbStudentNumber.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][i].number);
                    cbStudentName.Items.Add(DataManager.ProfessionalMasterGroup[cbStudentGroups.SelectedIndex - 1][i].name);
                }
                cbStudentNumber.SelectedIndex = 0;
            }
            else if(cbStudentType.SelectedIndex == 2)
            {
                cbStudentNumber.Items.Clear();
                cbStudentNumber.Items.Add("全部学生");
                cbStudentName.Items.Clear();
                cbStudentName.Items.Add("全部学生");
                for (int i = 0; i < DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1].Count; ++i)
                {
                    cbStudentNumber.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][i].number);
                    cbStudentName.Items.Add(DataManager.AcademicMasterGroup[cbStudentGroups.SelectedIndex - 1][i].name);
                }
                cbStudentNumber.SelectedIndex = 0;
            }
        }

        private void btAdjustStudent_Click(object sender, EventArgs e)
        {
            if(cbAdjustGroups.SelectedIndex < 0)
            {
                MessageBox.Show("没有选择调整的分组");
                return;
            }
            if(cbStudentNumber.SelectedIndex <= 0)
            {
                MessageBox.Show("没有学生，不能调整分组");
                return;
            }
            if(cbAdjustGroups.SelectedIndex == cbStudentGroups.SelectedIndex - 1)
            {
                MessageBox.Show("不能调整到同一组");
                return;
            }
            DataManager.AdjustStudent(cbStudentType.SelectedIndex, cbStudentGroups.SelectedIndex - 1, cbAdjustGroups.SelectedIndex, cbStudentNumber.Text);
            if (cbStudentType.SelectedIndex == 1)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbAdjustGroups.Items.Clear();
                for (int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                    cbAdjustGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbStudentGroups.Items.Clear();
                cbStudentGroups.Items.Add("全部学生");
                cbAdjustGroups.Items.Clear();
                for (int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbStudentGroups.Items.Add("第" + i + "组");
                    cbAdjustGroups.Items.Add("第" + i + "组");
                }
                cbStudentGroups.SelectedIndex = 0;
            }
        }
    }
}

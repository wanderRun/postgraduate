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
    public partial class StudentDetail : Form
    {
        private int index;

        public StudentDetail(int index)
        {
            this.index = index;
            InitializeComponent();
            this.ShowStudentDetail();
        }

        private void ShowStudentDetail()
        {
            tbApplyPlace.Text = DataManager.Students.student[index].apply_place;
            tbApllyNumber.Text = DataManager.Students.student[index].aplly_number;
            tbName.Text = DataManager.Students.student[index].name;
            tbNameSpell.Text = DataManager.Students.student[index].name_spell;
            tbNumber.Text = DataManager.Students.student[index].number;
            tbCardType.Text = DataManager.Students.student[index].card_type;
            tbCardNumber.Text = DataManager.Students.student[index].card_number;
            tbBirth.Text = DataManager.Students.student[index].birth;
            tbNation.Text = DataManager.Students.student[index].nation;
            tbGender.Text = DataManager.Students.student[index].gender;
            tbMarriage.Text = DataManager.Students.student[index].marriage;
            tbSoldier.Text = DataManager.Students.student[index].soldier;
            tbPoliticsStatus.Text = DataManager.Students.student[index].politics_status;
            tbNativePlace.Text = DataManager.Students.student[index].native_place;
            tbBirthPlace.Text = DataManager.Students.student[index].birth_place;
            tbRegisterPlace.Text = DataManager.Students.student[index].register_place;
            tbRegisterAddress.Text = DataManager.Students.student[index].register_address;
            tbRecordPlace.Text = DataManager.Students.student[index].record_place;
            tbRecordMinistry.Text = DataManager.Students.student[index].record_ministry;
            tbRecordAddress.Text = DataManager.Students.student[index].record_address;
            tbRecordPlacePostcode.Text = DataManager.Students.student[index].record_place_postcode;
            tbWorkPlace.Text = DataManager.Students.student[index].work_place;
            tbWorkExperience.Text = DataManager.Students.student[index].work_experience;
            tbRewardPunishment.Text = DataManager.Students.student[index].reward_punishment;
            tbFamily.Text = DataManager.Students.student[index].family;
            tbContactAddress.Text = DataManager.Students.student[index].contact_address;
            tbContactPostcode.Text = DataManager.Students.student[index].contact_postcode;
            tbFixedLinePhone.Text = DataManager.Students.student[index].fixed_line_phone;
            tbMobilePhone.Text = DataManager.Students.student[index].mobile_phone;
            tbEmail.Text = DataManager.Students.student[index].email;
            tbSource.Text = DataManager.Students.student[index].source;
            tbSameEducation.Text = DataManager.Students.student[index].same_education.ToString();
            tbSchoolCode.Text = DataManager.Students.student[index].school_code;
            tbSchoolName.Text = DataManager.Students.student[index].school_name;
            tbMajorName.Text = DataManager.Students.student[index].major_name;
            tbStudyType.Text = DataManager.Students.student[index].study_type;
            tbLastEducation.Text = DataManager.Students.student[index].last_education;
            tbDiplomaNumber.Text = DataManager.Students.student[index].diploma_number;
            tbGraduateDate.Text = DataManager.Students.student[index].graduate_date;
            tbRegisterNumber.Text = DataManager.Students.student[index].register_number;
            tbLastDegree.Text = DataManager.Students.student[index].last_degree;
            tbGraduateNumber.Text = DataManager.Students.student[index].graduate_number;
            tbAdjustMajorCode.Text = DataManager.Students.student[index].adjust_major_code;
            tbAdjustMajorName.Text = DataManager.Students.student[index].adjust_major_name;
            tbApplyPlaceCode.Text = DataManager.Students.student[index].apply_place_code;
            tbApplyFaculty.Text = DataManager.Students.student[index].apply_faculty;
            tbApplyFacultyName.Text = DataManager.Students.student[index].apply_faculty_name;
            tbApplyMajorCode.Text = DataManager.Students.student[index].apply_major_code;
            tbApplyMajorName.Text = DataManager.Students.student[index].apply_major_name;
            tbApplyWorkDirection.Text = DataManager.Students.student[index].apply_work_direction;
            tbApplyWorkDirectionName.Text = DataManager.Students.student[index].apply_work_direction_name;
            tbExamType.Text = DataManager.Students.student[index].exam_type;
            tbSpecialPlan.Text = DataManager.Students.student[index].special_plan;
            tbApplyType.Text = DataManager.Students.student[index].apply_type;
            tbOrientationTrainPlaceCode.Text = DataManager.Students.student[index].orientation_train_place_code;
            tbOrientationTrainPlace.Text = DataManager.Students.student[index].orientation_train_place;
            tbStandbyInformation.Text = DataManager.Students.student[index].standby_information;
            tbStandbyInformationOne.Text = DataManager.Students.student[index].standby_information_one;
            tbStandbyInformationTwo.Text = DataManager.Students.student[index].standby_information_two;
            tbStandbyInformationThree.Text = DataManager.Students.student[index].standby_information_three;
            tbPoliticalCode.Text = DataManager.Students.student[index].political_code;
            tbPoliticalName.Text = DataManager.Students.student[index].political_name;
            tbForeignCode.Text = DataManager.Students.student[index].foreign_code;
            tbForeignName.Text = DataManager.Students.student[index].foreign_name;
            tbBusinessOneCode.Text = DataManager.Students.student[index].business_one_code;
            tbBusinessOneName.Text = DataManager.Students.student[index].business_one_name;
            tbBusinessTwoCode.Text = DataManager.Students.student[index].business_two_code;
            tbBusinessTwoName.Text = DataManager.Students.student[index].business_two_name;
            tbPoliticalScore.Text = DataManager.Students.student[index].political_score.ToString();
            tbForeignScore.Text = DataManager.Students.student[index].foreign_score.ToString();
            tbBusinessOneScore.Text = DataManager.Students.student[index].business_one_score.ToString();
            tbBusinessTwoScore.Text = DataManager.Students.student[index].business_two_score.ToString();
            tbTotalScore.Text = DataManager.Students.student[index].total_score.ToString();
            tbVolunteerType.Text = DataManager.Students.student[index].volunteer_type;
            tbTutor.Text = DataManager.Students.student[index].tutor;
            tbStudentConfirmStatus.Text = DataManager.Students.student[index].student_confirm_status;
            tbStudentConfirmTime.Text = DataManager.Students.student[index].student_confirm_time.ToString();
            tbStudentReexamine.Text = DataManager.Students.student[index].student_reexamine;
        }
    }
}

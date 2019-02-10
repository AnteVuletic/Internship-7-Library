using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories;
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Member_forms
{
    public partial class MemberEdit : Form
    {
        private readonly MemberRepo _memberRepo;
        private readonly InstitutionRepo _institutionRepo;
        private int _index;
        private bool _firstIteration;
        public MemberEdit()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _memberRepo = new MemberRepo(personRepo);
            _institutionRepo = new InstitutionRepo();
            _firstIteration = true;
            _index = 0;
            SetData();
        }
        public bool SetData()
        {
            if (_firstIteration)
            {
                foreach (var institution in _institutionRepo.GetAllInstitutions())
                {
                    institutionComboBox.Items.Add(institution.Name);
                }

                _firstIteration = false;
            }

            if (_memberRepo.GetAllMembers().Count == 0)
            {
                MessageBox.Show("No student or professor has been added yet", "Member not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                institutionComboBox.Text = "";
                isProfessorCheckBox.Checked = false;
                btnSave.Enabled = false;
            }

            if (_memberRepo.GetAllMembers().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _memberRepo.GetAllMembers()[_index].Person.Name;
            surnameTextBox.Text = _memberRepo.GetAllMembers()[_index].Person.Surname;
            dateOfBirthPicker.Value = _memberRepo.GetAllMembers()[_index].Person.DateOfBirth.Value;
            institutionComboBox.Text = _memberRepo.GetAllMembers()[_index].Institution.Name;
            isProfessorCheckBox.Checked = _memberRepo.GetAllMembers()[_index].Professor;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_memberRepo.EditMember(_memberRepo.GetAllMembers()[_index].MemberId, nameTextBox.Text,
                surnameTextBox.Text,
                dateOfBirthPicker.Value, isProfessorCheckBox.Checked,
                _institutionRepo.GetInstitutionByName(institutionComboBox.Text)))
            {
                MessageBox.Show("This person is already an member", "Member exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            SetData();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _index--;
            if (!SetData()) _index++;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _index++;
            if (!SetData()) _index--;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

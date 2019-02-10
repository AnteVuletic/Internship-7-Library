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
    public partial class MemberRemove : Form
    {
        private readonly MemberRepo _memberRepo;
        private int _index;
        public MemberRemove()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _memberRepo = new MemberRepo(personRepo);
            _index = 0;
            SetData();
        }

        public bool SetData()
        {
            if (_memberRepo.GetAllMembers().Count == 0)
            {
                MessageBox.Show("No student or professor has been added yet", "Member not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                institutionComboBox.Text = "";
                btnDelete.Enabled = false;
            }

            if (_memberRepo.GetAllMembers().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _memberRepo.GetAllMembers()[_index].Person.Name;
            surnameTextBox.Text = _memberRepo.GetAllMembers()[_index].Person.Surname;
            dateOfBirthPicker.Value = _memberRepo.GetAllMembers()[_index].Person.DateOfBirth.Value;
            institutionComboBox.Text = _memberRepo.GetAllMembers()[_index].Institution.Name;
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_memberRepo.RemoveMember(_memberRepo.GetAllMembers()[_index].MemberId))
            {
                MessageBox.Show("Cannot remove member that is currently renting an book", "Rent error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _index = 0;
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

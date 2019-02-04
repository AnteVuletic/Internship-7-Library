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
    public partial class MemberAdd : Form
    {
        private readonly MemberRepo _memberRepo;
        private readonly InstitutionRepo _institutionRepo;
        private bool _firstIteration;
        public MemberAdd()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _memberRepo = new MemberRepo(personRepo);
            _institutionRepo = new InstitutionRepo();
            _firstIteration = true;
            NewForm();
        }

        private void NewForm()
        {
            dateOfBirthPicker.MaxDate = new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day);
            dateOfBirthPicker.Value =
                new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day - 2);
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            institutionComboBox.SelectedIndex = -1;
            isProfessorCheckBox.Checked = false;
            if (!_firstIteration) return;
            foreach (var institution in _institutionRepo.GetAllInstitutions())
            {
                institutionComboBox.Items.Add(institution.Name);
            }

            _firstIteration = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _memberRepo.AddMember(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,isProfessorCheckBox.Checked,
                _institutionRepo.GetInstitutionByName(institutionComboBox.Text));
            NewForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

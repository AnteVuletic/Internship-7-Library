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
            var allInstitutions = _institutionRepo.GetAllInstitutions();
            if (allInstitutions.Count == 0)
            {
                MessageBox.Show("Please add Institutions before adding students and professors.",
                    "Institution not exists error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            foreach (var institution in allInstitutions)
            {
                institutionComboBox.Items.Add(institution.Name);
            }

            _firstIteration = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmptyChecker.TryTextFieldsEmpty(Controls))
            {
                MessageBox.Show("Please make sure you enter a value for all text fields", "Value empty error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TextBoxParser.TextBoxChecker(Controls);
            if (institutionComboBox.Text == "")
            {
                MessageBox.Show("Please pick an institution before trying to save", "Institution empty error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_memberRepo.AddMember(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,
                isProfessorCheckBox.Checked,
                _institutionRepo.GetInstitutionByName(institutionComboBox.Text)))
            {
                MessageBox.Show("This person is already an member.", "Member exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            NewForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

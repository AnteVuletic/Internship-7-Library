using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Data.Enums;
using Internship_7_Library.Domain.Repositories;

namespace Intership_7_Library.Presentation.Staff_forms
{
    public partial class StaffAdd : Form
    {
        private readonly StaffRepo _staffRepo;
        private bool _firstIteration;
        public StaffAdd()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _staffRepo = new StaffRepo(personRepo);
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
            comboPosition.SelectedIndex = -1;
            if (!_firstIteration) return;
            foreach (var positionName in Enum.GetNames(typeof(StaffPosition)))
            {
                comboPosition.Items.Add(positionName);
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
            if (comboPosition.Text == "")
            {
                MessageBox.Show("Please choose an position for this person before clicking save",
                    "Position empty error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_staffRepo.AddStaff(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,
                (StaffPosition) Enum.Parse(typeof(StaffPosition), comboPosition.Text)))
            {
                MessageBox.Show("There's person is already an staff member", "Staff member exists error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

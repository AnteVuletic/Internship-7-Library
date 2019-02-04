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
            _staffRepo.AddStaff(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,
                (StaffPosition) Enum.Parse(typeof(StaffPosition), comboPosition.Text));
            NewForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

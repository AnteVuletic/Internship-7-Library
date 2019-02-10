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
    public partial class StaffEdit : Form
    {
        private readonly StaffRepo _staffRepo;
        private int _index;
        private bool _firstIteration;
        public StaffEdit()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _staffRepo = new StaffRepo(personRepo);
            _index = 0;
            _firstIteration = true;
            SetData();
        }
        private bool SetData()
        {
            if (_firstIteration)
            {
                foreach (var positionName in Enum.GetNames(typeof(StaffPosition)))
                {
                    comboPosition.Items.Add(positionName);
                }

                _firstIteration = false;
            }
            if (_staffRepo.GetAllStaff().Count == 0)
            {
                MessageBox.Show("No staff have been added yet", "Staff not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                comboPosition.Text = "";
                btnSave.Enabled = false;
            }

            if (_staffRepo.GetAllStaff().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _staffRepo.GetAllStaff()[_index].Person.Name;
            surnameTextBox.Text = _staffRepo.GetAllStaff()[_index].Person.Surname;
            dateOfBirthPicker.Value = _staffRepo.GetAllStaff()[_index].Person.DateOfBirth.Value;
            comboPosition.Text = Enum.GetName(typeof(StaffPosition), _staffRepo.GetAllStaff()[_index].Position);
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_staffRepo.EditStaff(_staffRepo.GetAllStaff()[_index].StaffId, nameTextBox.Text, surnameTextBox.Text,
                dateOfBirthPicker.Value, (StaffPosition) Enum.Parse(typeof(StaffPosition), comboPosition.Text)))
            {
                MessageBox.Show("This person already exists", "Person exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            SetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}

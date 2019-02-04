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
    public partial class StaffRemove : Form
    {
        private readonly StaffRepo _staffRepo;
        private int _index;
        public StaffRemove(StaffRepo staffRepo)
        {
            InitializeComponent();
            _staffRepo = staffRepo;
            _index = 0;
            SetData();
        }

        private bool SetData()
        {
            if (_staffRepo.GetAllStaff().Count == 0)
            {
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                comboPosition.Text = "";
            }

            if (_staffRepo.GetAllStaff().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _staffRepo.GetAllStaff()[_index].Person.Name;
            surnameTextBox.Text = _staffRepo.GetAllStaff()[_index].Person.Surname;
            dateOfBirthPicker.Value = _staffRepo.GetAllStaff()[_index].Person.DateOfBirth.Value;
            comboPosition.Text = Enum.GetName(typeof(StaffPosition),_staffRepo.GetAllStaff()[_index].Position);
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _staffRepo.RemoveStaff(_staffRepo.GetAllStaff()[_index].StaffId);
            _index = 0;
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Institution_forms
{
    public partial class InstitutionRemove : Form
    {
        private readonly InstitutionRepo _institutionRepo;
        private int _index;
        public InstitutionRemove()
        {
            InitializeComponent();
            _institutionRepo = new InstitutionRepo();
            _index = 0;
            SetData();
        }

        public bool SetData()
        {
            if (_institutionRepo.GetAllInstitutions().Count == 0)
            {
                MessageBox.Show("No institution has been added yet", "Institution not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                addressTextBox.Text = "";
                btnDelete.Enabled = false;
            }

            if (_institutionRepo.GetAllInstitutions().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _institutionRepo.GetAllInstitutions()[_index].Name;
            addressTextBox.Text = _institutionRepo.GetAllInstitutions()[_index].Address;
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_institutionRepo.RemoveInstitution(_institutionRepo.GetAllInstitutions()[_index].InstitutionId))
            {
                MessageBox.Show(
                    "Institution cannot be deleted because it's being used to describe an student/professor",
                    "Cascading delete not allowed error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
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

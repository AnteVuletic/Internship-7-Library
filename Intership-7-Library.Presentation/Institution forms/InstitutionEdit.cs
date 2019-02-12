using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories.Member;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Intership_7_Library.Presentation.Institution_forms
{
    public partial class InstitutionEdit : Form
    {
        private readonly InstitutionRepo _institutionRepo;
        private int _index;
        public InstitutionEdit()
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
                btnSave.Enabled = false;
            }

            if (_institutionRepo.GetAllInstitutions().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _institutionRepo.GetAllInstitutions()[_index].Name;
            addressTextBox.Text = _institutionRepo.GetAllInstitutions()[_index].Address;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBoxParser.TextBoxChecker(Controls);
            if (!_institutionRepo.EditInstitution(_institutionRepo.GetAllInstitutions()[_index].InstitutionId,
                nameTextBox.Text, addressTextBox.Text))
            {
                MessageBox.Show("Institution with that name already exists", "Institution exists error", MessageBoxButtons.OK,
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

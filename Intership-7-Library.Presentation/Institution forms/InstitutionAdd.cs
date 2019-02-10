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

namespace Intership_7_Library.Presentation.Institution_forms
{
    public partial class InstitutionAdd : Form
    {
        private readonly InstitutionRepo _institutionRepo;
        public InstitutionAdd()
        {
            InitializeComponent();
            _institutionRepo = new InstitutionRepo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_institutionRepo.AddInstitution(nameTextBox.Text, addressTextBox.Text))
            {
                MessageBox.Show("There's already an institution called like this", "Institution exists error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nameTextBox.Text = "";
            addressTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InstitutionAdd_Load(object sender, EventArgs e)
        {

        }
    }
}

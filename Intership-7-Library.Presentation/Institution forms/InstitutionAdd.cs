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
        public InstitutionAdd(InstitutionRepo institutionRepo)
        {
            InitializeComponent();
            _institutionRepo = institutionRepo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _institutionRepo.AddInstitution(nameTextBox.Text, addressTextBox.Text);
            nameTextBox.Text = "";
            addressTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

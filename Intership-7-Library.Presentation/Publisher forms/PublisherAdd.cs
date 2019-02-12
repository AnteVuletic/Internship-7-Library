using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories.Book;

namespace Intership_7_Library.Presentation.Publisher__forms
{
    public partial class PublisherAdd : Form
    {
        private readonly PublisherRepo _publisherRepo;
        public PublisherAdd()
        {
            InitializeComponent();
            _publisherRepo = new PublisherRepo();
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
            if (!_publisherRepo.AddPublisher(nameTextBox.Text, countryTextBox.Text))
            {
                MessageBox.Show("There's already an publisher with this name.", "Publisher exists error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nameTextBox.Text = "";
            countryTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

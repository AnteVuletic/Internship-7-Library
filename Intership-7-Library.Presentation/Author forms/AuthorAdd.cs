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
using Internship_7_Library.Domain.Repositories.Book;

namespace Intership_7_Library.Presentation
{
    public partial class AuthorAdd : Form
    {
        private readonly AuthorRepo _authorRepo;

        public AuthorAdd()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _authorRepo = new AuthorRepo(personRepo);
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
            if (!_authorRepo.AddAuthor(nameTextBox.Text, surnameTextBox.Text))
            {
                MessageBox.Show("There is already an author with this name and surname.","Author exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

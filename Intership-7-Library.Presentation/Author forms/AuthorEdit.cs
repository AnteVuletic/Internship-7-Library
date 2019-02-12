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

namespace Intership_7_Library.Presentation.Author_forms
{
    public partial class AuthorEdit : Form
    {
        private readonly AuthorRepo _authorRepo;
        private int _index;
        public AuthorEdit()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _authorRepo = new AuthorRepo(personRepo);
            _index = 0;
            SetData();
        }

        private bool SetData()
        {
            if (_authorRepo.GetAllAuthors().Count == 0)
            {
                MessageBox.Show("No authors have been added yet", "Authors not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnSave.Enabled = false;
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
            }
            if (_authorRepo.GetAllAuthors().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _authorRepo.GetAllAuthors()[_index].AuthorPerson.Name;
            surnameTextBox.Text = _authorRepo.GetAllAuthors()[_index].AuthorPerson.Surname;
            return true;
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
            if (!_authorRepo.EditAuthor(_authorRepo.GetAllAuthors()[_index].AuthorId, nameTextBox.Text,
                surnameTextBox.Text))
            {
                MessageBox.Show("Error editing Author, publisher with name and surname already exists",
                    "Author exists error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

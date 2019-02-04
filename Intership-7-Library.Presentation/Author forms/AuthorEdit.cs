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

namespace Intership_7_Library.Presentation.Author_forms
{
    public partial class AuthorEdit : Form
    {
        private readonly AuthorRepo _authorRepo;
        private int _index;
        public AuthorEdit(AuthorRepo authorRepo)
        {
            InitializeComponent();
            _authorRepo = authorRepo;
            _index = 0;
            SetData();
        }

        private bool SetData()
        {
            if (_authorRepo.GetAllAuthors().Count == 0)
            {
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
            _authorRepo.EditAuthor(_authorRepo.GetAllAuthors()[_index].AuthorId, nameTextBox.Text, surnameTextBox.Text);
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

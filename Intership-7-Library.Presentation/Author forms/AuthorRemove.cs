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
    public partial class AuthorRemove : Form
    {
        private readonly AuthorRepo _authorRepo;
        private int _index;
        public AuthorRemove()
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
                btnDelete.Enabled = false;
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
            }
            if (_authorRepo.GetAllAuthors().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _authorRepo.GetAllAuthors()[_index].AuthorPerson.Name;
            surnameTextBox.Text = _authorRepo.GetAllAuthors()[_index].AuthorPerson.Surname;
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_authorRepo.RemoveAuthor(_authorRepo.GetAllAuthors()[_index].AuthorId))
            {
                MessageBox.Show("Author cannot be removed because it's info is being used to describe an book.", "Cascading delete not allowed error", MessageBoxButtons.OK,
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

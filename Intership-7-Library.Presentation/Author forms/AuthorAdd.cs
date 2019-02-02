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

namespace Intership_7_Library.Presentation
{
    public partial class AuthorAdd : Form
    {
        private readonly AuthorRepo _authorRepo;
        public AuthorAdd(AuthorRepo authorRepo)
        {
            InitializeComponent();
            _authorRepo = authorRepo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _authorRepo.AddAuthor(nameTextBox.Text, surnameTextBox.Text);
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

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

namespace Intership_7_Library.Presentation.Genre
{
    public partial class GenreAdd : Form
    {
        private readonly GenreRepo _genreRepo;
        public GenreAdd(GenreRepo genreRepo)
        {
            InitializeComponent();
            _genreRepo = genreRepo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _genreRepo.AddGenre(genreTextBox.Text, descriptionTextBox.Text);
            genreTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

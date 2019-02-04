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

namespace Intership_7_Library.Presentation.Genre_forms
{
    public partial class GenreRemove : Form
    {
        private readonly GenreRepo _genreRepo;
        private int _index;
        public GenreRemove(GenreRepo genreRepo)
        {
            InitializeComponent();
            _genreRepo = genreRepo;
            _index = 0;
            SetData();
        }

        public bool SetData()
        {
            if (_genreRepo.GetAllGenres().Count == 0)
            {
                genreTextBox.Text = "";
                descriptionTextBox.Text = "";
            }
            if (_genreRepo.GetAllGenres().Count <= _index || _index < 0)
            return false;
            genreTextBox.Text = _genreRepo.GetAllGenres()[_index].Name;
            descriptionTextBox.Text = _genreRepo.GetAllGenres()[_index].Description;
            return true;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _genreRepo.RemoveGenre(_genreRepo.GetAllGenres()[_index].GenreId);
            _index = 0;
            SetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

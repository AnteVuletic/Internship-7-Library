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
    public partial class GenreEdit : Form
    {
        private readonly GenreRepo _genreRepo;
        private int _index;
        public GenreEdit()
        {
            InitializeComponent();
            _genreRepo = new GenreRepo();
            _index = 0;
            SetData();
        }
        public bool SetData()
        {
            if (_genreRepo.GetAllGenres().Count == 0)
            {
                MessageBox.Show("No genre has been added yet", "Genre not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                genreTextBox.Text = "";
                descriptionTextBox.Text = "";
                btnSave.Enabled = false;
            }
            if (_genreRepo.GetAllGenres().Count <= _index || _index < 0)
                return false;
            genreTextBox.Text = _genreRepo.GetAllGenres()[_index].Name;
            descriptionTextBox.Text = _genreRepo.GetAllGenres()[_index].Description;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text == "") descriptionTextBox.Text = "-";
            if (EmptyChecker.TryTextFieldsEmpty(Controls))
            {
                MessageBox.Show("Please make sure you enter a value for all text fields", "Value empty error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TextBoxParser.TextBoxChecker(Controls);
            if (!_genreRepo.EditGenre(_genreRepo.GetAllGenres()[_index].GenreId, genreTextBox.Text,
                descriptionTextBox.Text))
            {
                MessageBox.Show("Genre with this name already exists", "Genre exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            SetData();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

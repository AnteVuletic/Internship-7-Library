﻿using System;
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
        public GenreRemove()
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
                btnDelete.Enabled = false;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_genreRepo.RemoveGenre(_genreRepo.GetAllGenres()[_index].GenreId))
            {
                MessageBox.Show("Genre cannot be deleted because it's being used to describe an book",
                    "Cascading delete not allowed error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _index = 0;
            SetData();
        }


    }
}

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

namespace Intership_7_Library.Presentation.Genre
{
    public partial class GenreAdd : Form
    {
        private readonly GenreRepo _genreRepo;
        public GenreAdd()
        {
            InitializeComponent();
            _genreRepo = new GenreRepo();
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
            if (!_genreRepo.AddGenre(genreTextBox.Text, descriptionTextBox.Text))
            {
                MessageBox.Show("There's already a genre called like this", "Genre exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            genreTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

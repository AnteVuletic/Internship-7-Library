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

namespace Intership_7_Library.Presentation.Book_forms
{
    public partial class BookAdd : Form
    {
        private readonly TypeBookRepo _typeBookRepo;
        private readonly BookRepo _bookRepo;
        private readonly GenreRepo _genreRepo;
        private readonly PublisherRepo _publisherRepo;
        private readonly AuthorRepo _authorRepo;
        private bool _firstIteration;
        public BookAdd()
        {
            InitializeComponent();
            var _personRepo = new PersonRepo();
            _bookRepo = new BookRepo();
            _typeBookRepo = new TypeBookRepo(_bookRepo);
            _genreRepo = new GenreRepo();
            _publisherRepo = new PublisherRepo();
            _authorRepo = new AuthorRepo(_personRepo);
            _firstIteration = true;
            StartingPoint();
        }

        private void StartingPoint()
        {
            genreCombo.SelectedIndex = -1;
            publisherCombo.SelectedIndex= -1;
            authorCombo.SelectedIndex = -1;
            titleTextBox.Text = "";
            numberTextBox.Text = "";
            copiesTextBox.Text = "";
            if (!_firstIteration) return;
            var allGenres = _genreRepo.GetAllGenres();
            var allPublishers = _publisherRepo.GetAllPublisher();
            var allAuthors = _authorRepo.GetAllAuthors();
            if (allGenres.Count == 0)
            {
                MessageBox.Show("There's no genres to choose from, make sure to add genres before adding book types.", "Genres not exist error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            foreach (var genre in allGenres)
            {
                genreCombo.Items.Add(genre.Name);
            }

            if (allPublishers.Count == 0)
            {
                MessageBox.Show("There's no publishers to choose from, make sure to add publishers before adding book types", "Publisher not exist error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            foreach (var publisher in allPublishers)
            {
                publisherCombo.Items.Add(publisher.Name);
            }

            if (allAuthors.Count == 0)
            {
                MessageBox.Show("There's no authors to choose from, make sure to add authors before adding book types", "Author not exist error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            foreach (var author in allAuthors)
            {
                authorCombo.Items.Add(author.AuthorPerson.Name + " " + author.AuthorPerson.Surname);
            }
            _firstIteration = false;
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
            if (genreCombo.Text == "" || authorCombo.Text == "" || publisherCombo.Text == "")
            {
                MessageBox.Show("Please choose an value for all drop down menus before clicking save",
                    "Combobox empty error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_typeBookRepo.AddBooks(titleTextBox.Text, numberTextBox.Text,
                _genreRepo.GetGenreByText(genreCombo.Text),
                _authorRepo.GetAuthorByName(authorCombo.Text),
                _publisherRepo.GetPublisherByName(publisherCombo.Text), int.Parse(copiesTextBox.Text)))
            {
                MessageBox.Show("There is already an book with this title from this publisher.", "Type of book exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            StartingPoint();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); ;
        }

        private void copiesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); ;
        }
    }
}

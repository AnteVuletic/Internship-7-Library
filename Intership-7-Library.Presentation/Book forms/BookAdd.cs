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
            foreach (var genre in _genreRepo.GetAllGenres())
            {
                genreCombo.Items.Add(genre.Name);
            }

            foreach (var publisher in _publisherRepo.GetAllPublisher())
            {
                publisherCombo.Items.Add(publisher.Name);
            }

            foreach (var author in _authorRepo.GetAllAuthors())
            {
                authorCombo.Items.Add(author.AuthorPerson.Name + " " + author.AuthorPerson.Surname);
            }
            _firstIteration = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _typeBookRepo.AddBooks(titleTextBox.Text, numberTextBox.Text,
                _genreRepo.GetGenreByText(genreCombo.Text),
                _authorRepo.GetAuthorByName(authorCombo.Text),
                _publisherRepo.GetPublisherByName(publisherCombo.Text), int.Parse(copiesTextBox.Text));
            StartingPoint();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

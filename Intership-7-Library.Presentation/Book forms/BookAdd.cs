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

namespace Intership_7_Library.Presentation.Book_forms
{
    public partial class BookAdd : Form
    {
        private readonly TypeBookRepo _typeBookRepo;
        private readonly BookRepo _bookRepo;
        private readonly GenreRepo _genreRepo;
        private readonly PublisherRepo _publisherRepo;
        private readonly AuthorRepo _authorRepo;
        public BookAdd(TypeBookRepo typeBookRepo, BookRepo bookRepo, GenreRepo genreRepo, PublisherRepo publisherRepo,AuthorRepo authorRepo)
        {
            InitializeComponent();
            _typeBookRepo = typeBookRepo;
            _bookRepo = bookRepo;
            _genreRepo = genreRepo;
            _publisherRepo = publisherRepo;
            _authorRepo = authorRepo;
            StartingPoint();
        }

        private void StartingPoint()
        {
            genreCombo.Text = "";
            publisherCombo.Text = "";
            authorCombo.Text = "";
            titleTextBox.Text = "";
            numberTextBox.Text = "";
            copiesTextBox.Text = "";
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
                authorCombo.Items.Add(author.Name);
            }
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

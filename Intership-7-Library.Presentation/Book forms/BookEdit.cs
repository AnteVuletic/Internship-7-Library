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
    public partial class BookEdit : Form
    {
        private readonly TypeBookRepo _typeBook;
        private readonly AuthorRepo _authorRepo;
        private readonly PublisherRepo _publisherRepo;
        private readonly GenreRepo _genreRepo;
        private bool _firstIteration;
        private int _index;
        public BookEdit()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            var bookRepo = new BookRepo();
            _typeBook = new TypeBookRepo(bookRepo);
            _authorRepo = new AuthorRepo(personRepo);
            _publisherRepo = new PublisherRepo();
            _genreRepo = new GenreRepo();
            _index = 0;
            _firstIteration = true;
            SetData();
        }
        public bool SetData()
        {
            if (_firstIteration)
            {
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
            if (_typeBook.GetAllBookTypes().Count == 0)
            {
                titleTextBox.Text = "";
                numberTextBox.Text = "";
                genreCombo.Text = "";
                authorCombo.Text = "";
                publisherCombo.Text = "";
                publisherCombo.Text = "";
                copiesTextBox.Text = "";
            }
            if (_typeBook.GetAllBookTypes().Count <= _index || _index < 0) return false;
            titleTextBox.Text = _typeBook.GetAllBookTypes()[_index].Title;
            numberTextBox.Text = _typeBook.GetAllBookTypes()[_index].NumPages;
            genreCombo.Text = _typeBook.GetAllBookTypes()[_index].Genre.Name;
            authorCombo.Text = _typeBook.GetAllBookTypes()[_index].AuthorInfo.AuthorPerson.Name + " " +
                               _typeBook.GetAllBookTypes()[_index].AuthorInfo.AuthorPerson.Surname;
            publisherCombo.Text = _typeBook.GetAllBookTypes()[_index].Publisher.Name;
            copiesTextBox.Text = _typeBook.GetAllBookTypes()[_index].PhysicalBooks
                .Count(bk => bk.BookInfo.TypeBookId == _typeBook.GetAllBookTypes()[_index].TypeBookId).ToString();
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _typeBook.EditBook(_typeBook.GetAllBookTypes()[_index].TypeBookId, titleTextBox.Text, numberTextBox.Text,
                _genreRepo.GetGenreByText(genreCombo.Text),
                _authorRepo.GetAuthorByName(authorCombo.Text), _publisherRepo.GetPublisherByName(publisherCombo.Text),
                int.Parse(copiesTextBox.Text));
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

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

namespace Intership_7_Library.Presentation.Reports
{
    public partial class BookByAuthor : Form
    {
        private readonly PersonRepo _personRepo;
        private readonly AuthorRepo _authorRepo;
        public BookByAuthor()
        {
            InitializeComponent();
            _personRepo = new PersonRepo();
            _authorRepo = new AuthorRepo(_personRepo);
            InitializeList();
            RefreshInfo();
        }
        public void InitializeList()
        {
            bookListView.Columns.Add(new ColumnHeader("Author name").Text = "Author name").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Books").Text = "Books").Width = 100;
        }

        public void RefreshInfo()
        {
            bookListView.Items.Clear();
            var allBooksByAuthors = _authorRepo.GetAllAuthors().Where(ath => ath.AuthorPerson.Surname.Contains(srchAuthorTextBox.Text));
            foreach (var allBooksByAuthor in allBooksByAuthors)
            {
                var authorItem = new ListViewItem(allBooksByAuthor.AuthorPerson.Name + " " + allBooksByAuthor.AuthorPerson.Surname);
                var collectionOfBookTitles = "";
                var counter = 0;
                foreach (var books in allBooksByAuthor.BookInfos)
                {
                    collectionOfBookTitles += $" {(counter+1).ToString()}. {books.Title} ";
                    counter++;
                }

                authorItem.SubItems.Add(collectionOfBookTitles);
                bookListView.Items.Add(authorItem);
                if (bookListView.Columns[1].Width < counter * 100)
                {
                    bookListView.Columns[1].Width = counter * 100;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void srchAuthorTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }
}

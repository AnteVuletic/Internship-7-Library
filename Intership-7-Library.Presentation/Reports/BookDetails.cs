using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Data.Enums;
using Internship_7_Library.Domain.Repositories.Book;

namespace Intership_7_Library.Presentation.Reports
{
    public partial class BookDetails : Form
    {
        private readonly BookRepo _bookRepo;
        private readonly TypeBookRepo _typeBookRepo;
        public BookDetails()
        {
            InitializeComponent();
            _bookRepo = new BookRepo();
            _typeBookRepo = new TypeBookRepo(_bookRepo);
            InitializeList();
            RefreshInfo();
        }

        public void InitializeList()
        {
            bookListView.Columns.Add(new ColumnHeader("Book name").Text = "Book name").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Author name").Text = "Author name").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Publisher").Text = "Publisher").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Available number").Text = "Available").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Rented number").Text = "Rented").Width = 100;
        }

        public void RefreshInfo()
        {
            bookListView.Items.Clear();
            var allBooks = _typeBookRepo.GetAllBookTypes().Where(typBk => typBk.Title.Contains(srchBookTextBox.Text));
            foreach (var typeBook in allBooks)
            {
                var bookItem = new ListViewItem(typeBook.Title);
                bookItem.SubItems.Add(typeBook.AuthorInfo.AuthorPerson.Name + " " + typeBook.AuthorInfo.AuthorPerson.Surname);
                bookItem.SubItems.Add(typeBook.Publisher.Name);
                bookItem.SubItems.Add(typeBook.PhysicalBooks.Count(bk => bk.State == BookState.Available).ToString());
                bookItem.SubItems.Add(typeBook.PhysicalBooks.Count(bk => bk.State == BookState.Rented).ToString());
                bookListView.Items.Add(bookItem);
            }
        }
        private void srchBookTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

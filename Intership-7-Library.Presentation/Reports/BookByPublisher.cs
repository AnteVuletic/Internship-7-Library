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

namespace Intership_7_Library.Presentation.Reports
{
    public partial class BookByPublisher : Form
    {
        private readonly PublisherRepo _publisherRepo;
        public BookByPublisher()
        {
            InitializeComponent();
            _publisherRepo = new PublisherRepo();
            InitializeList();
            RefreshInfo();
        }
        public void InitializeList()
        {
            bookListView.Columns.Add(new ColumnHeader("Publisher name").Text = "Publisher name").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Books").Text = "Books").Width = 100;
        }

        public void RefreshInfo()
        {
            bookListView.Items.Clear();
            var allBooksByPublisher = _publisherRepo.GetAllPublisher().Where(pub => pub.Name.Contains(srchPublisherTextBox.Text));
            foreach (var publisher in allBooksByPublisher)
            {
                var authorItem = new ListViewItem(publisher.Name);
                var collectionOfBookTitles = "";
                var counter = 0;
                foreach (var books in publisher.BookInfos)
                {
                    collectionOfBookTitles += $" {(counter + 1).ToString()}. {books.Title} ";
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

        private void srchPublisherTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }
}

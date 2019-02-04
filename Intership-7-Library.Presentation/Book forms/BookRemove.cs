using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Data.Entities.Models;
using Internship_7_Library.Domain.Repositories.Book;

namespace Intership_7_Library.Presentation.Book_forms
{
    public partial class BookRemove : Form
    {
        private readonly TypeBookRepo _typeBook;
        private int _index;
        public BookRemove(TypeBookRepo typeBook)
        {
            InitializeComponent();
            _typeBook = typeBook;
            _index = 0;
            SetData();
        }

        public bool SetData()
        {
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _typeBook.RemoveAllBooks(_typeBook.GetAllBookTypes()[_index].TypeBookId);
            _index = 0;
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

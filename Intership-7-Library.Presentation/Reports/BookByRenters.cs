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

namespace Intership_7_Library.Presentation.Reports
{
    public partial class BookByRenters : Form
    {
        private readonly RentRepo _rentRepo;
        public BookByRenters()
        {
            InitializeComponent();
            _rentRepo = new RentRepo();
            InitializeList();
            RefreshInfo();
        }
        public void InitializeList()
        {
            bookListView.Columns.Add(new ColumnHeader("Renter surname").Text = "Surname").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Renter name").Text = "Name").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Book title").Text = "Book").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Rented date").Text = "Rented date").Width = 100;
            bookListView.Columns.Add(new ColumnHeader("Institution").Text = "Institution").Width = 150;
            bookListView.Columns.Add(new ColumnHeader("Subscription model").Text = "Subscription model").Width = 150;
        }

        public void RefreshInfo()
        {
            bookListView.Items.Clear();
            var allBooksRented = _rentRepo.GetAllCurrentlyRented().Where(rnt => rnt.Person.Surname.Contains(srchRenterTextBox.Text));
            foreach (var rent in allBooksRented)
            {
                var rentedItem = new ListViewItem(rent.Person.Surname);
                rentedItem.SubItems.Add(rent.Person.Name);
                rentedItem.SubItems.Add(rent.Book.BookInfo.Title);
                rentedItem.SubItems.Add(rent.StartOfRent.ToString("dd/MM/yyyy"));
                if (rent.Person.InstitutionMembers.Any(inst => inst.Person.PersonId == rent.PersonId))
                {
                    rentedItem.SubItems.Add(rent.Person.InstitutionMembers
                        .First(memb => memb.Person.PersonId == rent.PersonId).Institution.Name);
                    rentedItem.SubItems.Add("");
                }
                else
                {
                    rentedItem.SubItems.Add("");
                    rentedItem.SubItems.Add(rent.Person.Subscribers.First(sub => sub.Person.PersonId == rent.PersonId)
                        .TypeSubscription.Category);
                }
                bookListView.Items.Add(rentedItem);
            }
        }

        private void srchRenterTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

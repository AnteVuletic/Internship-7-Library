using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Data.Enums;
using Internship_7_Library.Domain.Repositories;
using Internship_7_Library.Domain.Repositories.Book;
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Rent_forms
{
    public partial class RentOut : Form
    {
        private readonly MemberRepo _memberRepo;
        private readonly SubscriberRepo _subscriberRepo;
        private readonly PersonRepo _personRepo;
        private readonly BookRepo _bookRepo;
        private readonly TypeBookRepo _typeBookRepo;
        private readonly RentRepo _rentRepo;
        public RentOut()
        {
            InitializeComponent();
            _personRepo = new PersonRepo();
            _memberRepo = new MemberRepo(_personRepo);
            _subscriberRepo = new SubscriberRepo(_personRepo);
            _bookRepo = new BookRepo();
            _typeBookRepo = new TypeBookRepo(_bookRepo);
            _rentRepo = new RentRepo();
            InitFormInfo();
        }

        private void InitFormInfo()
        {
            bookSearchTexBox.Text = "";
            memberSearchTextBox.Text = "";
            srchBookLabel.Visible = false;
            bookSearchTexBox.Visible = false;
            bookListView.Visible = false;
            AdjustMemberList();
            AdjustBookList();
        }
        private void AdjustMemberList()
        {
            listOfMembers.Items.Clear();
            foreach (var person in _personRepo.GetAllPersonsDetails().Where(prsn => prsn.Surname.Contains(memberSearchTextBox.Text) && ((prsn.InstitutionMembers.FirstOrDefault(memb => memb.Person.PersonId == prsn.PersonId) != null || prsn.Subscribers.FirstOrDefault(sub => sub.Person.PersonId == prsn.PersonId) != null))).ToList())
            {
                listOfMembers.Items.Add($"{person.Name} {person.Surname} {person.DateOfBirth.Value.ToString("dd/MM/yyyy")}");
            }
        }

        private void AdjustBookList()
        {
            bookListView.Items.Clear();
            foreach (var book in _typeBookRepo.GetAllBookTypes().Where(typBook => typBook.Title.Contains(bookSearchTexBox.Text) && typBook.PhysicalBooks.Count(bk => bk.State == BookState.Available) != 0))
            {
                bookListView.Items.Add($"{book.Title} by {book.AuthorInfo.AuthorPerson.Name} {book.AuthorInfo.AuthorPerson.Surname}");
            }
        }
        private void memberSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustMemberList();
        }

        private void listOfMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < listOfMembers.Items.Count; i++)
            {
                listOfMembers.Items[i].BackColor = DefaultBackColor;
            }
            if (listOfMembers.SelectedIndices.Count != 0)
            {
                listOfMembers.Items[listOfMembers.SelectedIndices[0]].BackColor = Color.Green;
            }

            srchBookLabel.Visible = true;
            bookSearchTexBox.Visible = true;
            bookListView.Visible = true;
        }

        private void bookSearchTexBox_TextChanged(object sender, EventArgs e)
        {
            AdjustBookList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            var parseStringBeforeSpace = new Regex(@"[^\s]+");
            var stringTitleMatch = parseStringBeforeSpace.Match(bookListView.SelectedItems[0].Text);
            var personMatches = parseStringBeforeSpace.Matches(listOfMembers.SelectedItems[0].Text);
            var personDateOfBirth = DateTime.ParseExact(personMatches[2].Value,"dd/MM/yyyy",null);
            var book = _bookRepo.GetBookIfAvailable(
                _typeBookRepo.GetBookTypeByTitle(stringTitleMatch.Value).TypeBookId);
            if(_rentRepo.RentBook(book,_personRepo.GetPersonByNameSurnameDate(personMatches[0].Value, personMatches[1].Value,personDateOfBirth)))
            {
                book.State = BookState.Rented;
            }
            InitFormInfo();
        }
    }
}

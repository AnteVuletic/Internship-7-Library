using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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
    public partial class RentReturn : Form
    {
        private readonly MemberRepo _memberRepo;
        private readonly SubscriberRepo _subscriberRepo;
        private readonly PersonRepo _personRepo;
        private readonly BookRepo _bookRepo;
        private readonly TypeBookRepo _typeBookRepo;
        private readonly RentRepo _rentRepo;
        private MatchCollection _personMatches;
        public RentReturn()
        {
            _personRepo = new PersonRepo();
            _memberRepo = new MemberRepo(_personRepo);
            _subscriberRepo = new SubscriberRepo(_personRepo);
            _bookRepo = new BookRepo();
            _typeBookRepo = new TypeBookRepo(_bookRepo);
            _rentRepo = new RentRepo();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            memberSearchTextBox.Text = "";
            bookSearchTexBox.Text = "";
            srchBookLabel.Visible = false;
            bookSearchTexBox.Visible = false;
            bookListView.Visible = false;
            AdjustMemberList();
        }
        private void AdjustMemberList()
        {
            listOfMembers.Items.Clear();
            foreach (var person in _personRepo.GetAllPersonsDetails().Where(prsn => prsn.Surname.Contains(memberSearchTextBox.Text) 
                                                                                    && ((prsn.InstitutionMembers.FirstOrDefault(memb => memb.Person.PersonId == prsn.PersonId) != null 
                                                                                         || prsn.Subscribers.FirstOrDefault(sub => sub.Person.PersonId == prsn.PersonId) != null))).ToList())
            {
                if(_rentRepo.GetAllCurrentlyRented().Any(bk=> bk.PersonId == person.PersonId))
                    listOfMembers.Items.Add($"{person.Name} {person.Surname} {person.DateOfBirth.Value.ToString("dd/MM/yyyy")}");
            }
        }

        private void AdjustBookList()
        {
            srchBookLabel.Visible = true;
            bookSearchTexBox.Visible = true;
            bookListView.Visible = true;
            var parseStringBeforeSpace = new Regex(@"[^\s]+");
            _personMatches = parseStringBeforeSpace.Matches(listOfMembers.SelectedItems[0].Text);
            bookListView.Items.Clear();
            foreach (var book in _bookRepo.GetBooks().Where(bk => bk.Rents.FirstOrDefault(rnt => rnt.Person.Name == _personMatches[0].Value 
                                                                                        && rnt.Person.Surname == _personMatches[1].Value 
                                                                                        && rnt.Person.DateOfBirth.Value == DateTime.ParseExact(_personMatches[2].Value, "dd/MM/yyyy", null)) 
                                                                  != null && bk.State == BookState.Rented))
            {
                bookListView.Items.Add($"{book.BookInfo.Title} by {book.BookInfo.AuthorInfo.AuthorPerson.Name} {book.BookInfo.AuthorInfo.AuthorPerson.Surname}");
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            var parseStringBeforeSpace = new Regex(@"[^\s]+");
            var stringTitleMatch = parseStringBeforeSpace.Match(bookListView.SelectedItems[0].Text);
            var bookInQuestion = _bookRepo.GetBooks().FirstOrDefault(bk => bk.BookInfo.Title == stringTitleMatch.Value
                                                                           && bk.Rents.FirstOrDefault(rnt => rnt.Person.Name == _personMatches[0].Value 
                                                                                                    && rnt.Person.Surname == _personMatches[1].Value 
                                                                                                    && rnt.Person.DateOfBirth.Value == DateTime.ParseExact(_personMatches[2].Value,"dd/MM/yyyy",null))!= null
                                                                           && bk.State == BookState.Rented);
            var personInQuestion = _personRepo.GetAllPersonsDetails().FirstOrDefault(prsn =>
            {
                if (prsn.Rents.Count == 0) return false;
                var relation = prsn.Rents.Where(rnt => rnt.BookId == bookInQuestion.BookId);
                return relation.Count(rltn => rltn.Person.Name == _personMatches[0].Value &&
                                              rltn.Person.Surname == _personMatches[1].Value &&
                                              rltn.Person.DateOfBirth.Value == DateTime.ParseExact(_personMatches[2].Value, "dd/MM/yyyy", null)) != 0;

            });
            _rentRepo.BookReturned(bookInQuestion, personInQuestion);
            InitializeForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
                AdjustBookList();
            }
            else
            {

                srchBookLabel.Visible = false;
                bookSearchTexBox.Visible = false;
                bookListView.Visible = false;
            }
        }

        private void memberSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustMemberList();
        }

        private void bookSearchTexBox_TextChanged(object sender, EventArgs e)
        {
            AdjustBookList();
        }
    }
}

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
using Internship_7_Library.Domain.Repositories.Member;
using Intership_7_Library.Presentation.Book_forms;
using Intership_7_Library.Presentation.Genre;
using Intership_7_Library.Presentation.Publisher__forms;

namespace Intership_7_Library.Presentation
{
    public partial class MainMenu : Form
    {
        private bool _isBookManager = false;
        private bool _isStaffManager = false;
        private bool _isMemberManager = false;
        private readonly GenreRepo _genreRepo;
        private readonly BookRepo _bookRepo;
        private readonly PersonRepo _personRepo;
        private readonly AuthorRepo _authorRepo;
        private readonly TypeBookRepo _typeBookRepo;
        private readonly InstitutionRepo _institutionRepo;
        private readonly MemberRepo _memberRepo;
        private readonly SubscriptionRepo _subscriptionRepo;
        private readonly SubscriberRepo _subscriberRepo;
        private readonly RentRepo _rentRepo;
        private readonly StaffRepo _staffRepo;
        private readonly PublisherRepo _publisherRepo;
        public MainMenu()
        {
            InitializeComponent();
            _genreRepo = new GenreRepo();
            _bookRepo = new BookRepo();
            _personRepo = new PersonRepo();
            _authorRepo = new AuthorRepo(_personRepo);
            _typeBookRepo = new TypeBookRepo(_bookRepo);
            _institutionRepo = new InstitutionRepo();
            _memberRepo = new MemberRepo(_personRepo);
            _subscriptionRepo = new SubscriptionRepo();
            _subscriberRepo = new SubscriberRepo(_personRepo);
            _rentRepo = new RentRepo();
            _staffRepo = new StaffRepo(_personRepo);
            _publisherRepo = new PublisherRepo();
        }

        public void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();
        }
        private void bookMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isBookManager)
            {
                bookMngDrpDwn.Size = bookMngDrpDwn.MaximumSize;
                _isBookManager = true;
            }
            else
            {
                bookMngDrpDwn.Size = bookMngDrpDwn.MinimumSize;
                _isBookManager = false;
            }
        }

        private void staffMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isStaffManager)
            {
                staffMngDrpDwn.Size = staffMngDrpDwn.MaximumSize;
                _isStaffManager = true;
            }
            else
            {
                staffMngDrpDwn.Size = staffMngDrpDwn.MinimumSize;
                _isStaffManager = false;
            }
        }

        private void memberMngDrpDwnBtn_Click(object sender, EventArgs e)
        {
            if (!_isMemberManager)
            {
                memberMngDrpDwn.Size = memberMngDrpDwn.MaximumSize;
                _isMemberManager = true;
            }
            else
            {
                memberMngDrpDwn.Size = memberMngDrpDwn.MinimumSize;
                _isMemberManager = false;
            }
        }

        private void genreAddBtn_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreAdd(_genreRepo);
            Nav(genreForm,contentPanel);
        }

        private void genreRemBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void genreEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookAddBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookAdd(_typeBookRepo, _bookRepo, _genreRepo, _publisherRepo, _authorRepo);
            Nav(bookForm,contentPanel);
        }

        private void bookRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorAdd(_authorRepo);
            Nav(authorForm, contentPanel);
        }

        private void authorRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void authorEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void publisherAddBtn_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherAdd(_publisherRepo);
            Nav(publisherForm,contentPanel);
        }

        private void publisherRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void publisherEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void staffEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void subRemoveBtn_Click(object sender, EventArgs e)
        {

        }

        private void subEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void instAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void instRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void instEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberRemBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberEditBtn_Click(object sender, EventArgs e)
        {

        }

    }
}

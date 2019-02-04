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
using Intership_7_Library.Presentation.Author_forms;
using Intership_7_Library.Presentation.Book_forms;
using Intership_7_Library.Presentation.Genre;
using Intership_7_Library.Presentation.Genre_forms;
using Intership_7_Library.Presentation.Institution_forms;
using Intership_7_Library.Presentation.Member_forms;
using Intership_7_Library.Presentation.Publisher_forms;
using Intership_7_Library.Presentation.Publisher__forms;
using Intership_7_Library.Presentation.Staff_forms;
using Intership_7_Library.Presentation.Subscriber_forms;
using Intership_7_Library.Presentation.Subscription_forms;

namespace Intership_7_Library.Presentation
{
    public partial class MainMenu : Form
    {
        private bool _isBookManager;
        private bool _isStaffManager;
        private bool _isMemberManager;
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
            var genreForm = new GenreRemove(_genreRepo);
            Nav(genreForm,contentPanel);
        }

        private void genreEditBtn_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreEdit(_genreRepo);
            Nav(genreForm,contentPanel);
        }

        private void bookAddBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookAdd(_typeBookRepo, _bookRepo, _genreRepo, _publisherRepo, _authorRepo);
            Nav(bookForm,contentPanel);
        }

        private void bookRemBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookRemove(_typeBookRepo);
            Nav(bookForm,contentPanel);
        }

        private void bookEditBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookEdit(_typeBookRepo, _authorRepo, _publisherRepo,_genreRepo);
            Nav(bookForm, contentPanel);
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorAdd(_authorRepo);
            Nav(authorForm, contentPanel);
        }

        private void authorRemBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorRemove(_authorRepo);
            Nav(authorForm,contentPanel);
        }

        private void authorEditBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorEdit(_authorRepo);
            Nav(authorForm, contentPanel);
        }

        private void publisherAddBtn_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherAdd(_publisherRepo);
            Nav(publisherForm,contentPanel);
        }

        private void publisherRemBtn_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherRemove(_publisherRepo);
            Nav(publisherForm,contentPanel);
        }

        private void publisherEditBtn_Click(object sender, EventArgs e)
        {
           var publisherForm = new PublisherEdit(_publisherRepo);
            Nav(publisherForm, contentPanel);
        }

        private void staffAddBtn_Click(object sender, EventArgs e)
        {
            var staffForm = new StaffAdd(_staffRepo);
            Nav(staffForm,contentPanel);
        }

        private void staffRemBtn_Click(object sender, EventArgs e)
        {
            var staffForm = new StaffRemove(_staffRepo);
            Nav(staffForm, contentPanel);
        }

        private void staffEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subTypeAddBtn_Click(object sender, EventArgs e)
        {
            var subTypeForm = new SubscriptionAdd(_subscriptionRepo);
            Nav(subTypeForm, contentPanel);
        }

        private void subTypeRemBtn_Click(object sender, EventArgs e)
        {
            var subTypeForm = new SubscriptionRemove(_subscriptionRepo);
            Nav(subTypeForm, contentPanel);
        }

        private void subTypeEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void subAddBtn_Click(object sender, EventArgs e)
        {
            var subForm = new SubscriberAdd(_subscriptionRepo, _subscriberRepo);
            Nav(subForm, contentPanel);
        }

        private void subRemoveBtn_Click(object sender, EventArgs e)
        {
            var subForm = new SubscriberRemove(_subscriberRepo);
            Nav(subForm,contentPanel);
        }

        private void subEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void instAddBtn_Click(object sender, EventArgs e)
        {
            var instForm = new InstitutionAdd(_institutionRepo);
            Nav(instForm,contentPanel);
        }

        private void instRemBtn_Click(object sender, EventArgs e)
        {
            var instForm = new InstitutionRemove(_institutionRepo);
            Nav(instForm, contentPanel);
        }

        private void instEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberAdd(_memberRepo, _institutionRepo);
            Nav(memberForm, contentPanel);
        }

        private void memberRemBtn_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberRemove(_memberRepo);
            Nav(memberForm,contentPanel);
        }

        private void memberEditBtn_Click(object sender, EventArgs e)
        {

        }

    }
}

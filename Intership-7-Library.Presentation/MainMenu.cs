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
using Intership_7_Library.Presentation.Rent_forms;
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
        public MainMenu()
        {
            InitializeComponent();
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
            var genreForm = new GenreAdd();
            Nav(genreForm,contentPanel);
        }

        private void genreRemBtn_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreRemove();
            Nav(genreForm,contentPanel);
        }

        private void genreEditBtn_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreEdit();
            Nav(genreForm,contentPanel);
        }

        private void bookAddBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookAdd();
            Nav(bookForm,contentPanel);
        }

        private void bookRemBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookRemove();
            Nav(bookForm,contentPanel);
        }

        private void bookEditBtn_Click(object sender, EventArgs e)
        {
            var bookForm = new BookEdit();
            Nav(bookForm, contentPanel);
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorAdd();
            Nav(authorForm, contentPanel);
        }

        private void authorRemBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorRemove();
            Nav(authorForm,contentPanel);
        }

        private void authorEditBtn_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorEdit();
            Nav(authorForm, contentPanel);
        }

        private void publisherAddBtn_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherAdd();
            Nav(publisherForm,contentPanel);
        }

        private void publisherRemBtn_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherRemove();
            Nav(publisherForm,contentPanel);
        }

        private void publisherEditBtn_Click(object sender, EventArgs e)
        {
           var publisherForm = new PublisherEdit();
            Nav(publisherForm, contentPanel);
        }

        private void staffAddBtn_Click(object sender, EventArgs e)
        {
            var staffForm = new StaffAdd();
            Nav(staffForm,contentPanel);
        }

        private void staffRemBtn_Click(object sender, EventArgs e)
        {
            var staffForm = new StaffRemove();
            Nav(staffForm, contentPanel);
        }

        private void staffEditBtn_Click(object sender, EventArgs e)
        {
            var staffForm = new StaffEdit();
            Nav(staffForm,contentPanel);
        }

        private void subTypeAddBtn_Click(object sender, EventArgs e)
        {
            var subTypeForm = new SubscriptionAdd();
            Nav(subTypeForm, contentPanel);
        }

        private void subTypeRemBtn_Click(object sender, EventArgs e)
        {
            var subTypeForm = new SubscriptionRemove();
            Nav(subTypeForm, contentPanel);
        }

        private void subTypeEditBtn_Click(object sender, EventArgs e)
        {
            var subTypeForm = new SubscriptionEdit();
            Nav(subTypeForm,contentPanel);
        }

        private void subAddBtn_Click(object sender, EventArgs e)
        {
            var subForm = new SubscriberAdd();
            Nav(subForm, contentPanel);
        }

        private void subRemoveBtn_Click(object sender, EventArgs e)
        {
            var subForm = new SubscriberRemove();
            Nav(subForm,contentPanel);
        }

        private void subEditBtn_Click(object sender, EventArgs e)
        {
            var subForm = new SubscriberEdit();
            Nav(subForm, contentPanel);
        }

        private void instAddBtn_Click(object sender, EventArgs e)
        {
            var instForm = new InstitutionAdd();
            Nav(instForm,contentPanel);
        }

        private void instRemBtn_Click(object sender, EventArgs e)
        {
            var instForm = new InstitutionRemove();
            Nav(instForm, contentPanel);
        }

        private void instEditBtn_Click(object sender, EventArgs e)
        {
            var instForm = new InstitutionEdit();
            Nav(instForm,contentPanel);
        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberAdd();
            Nav(memberForm, contentPanel);
        }

        private void memberRemBtn_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberRemove();
            Nav(memberForm,contentPanel);
        }

        private void memberEditBtn_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberEdit();
            Nav(memberForm, contentPanel);
        }

        private void rntBookBtn_Click(object sender, EventArgs e)
        {
            var rntForm = new RentOut();
            Nav(rntForm,contentPanel);
        }

        private void returnBookbtn_Click(object sender, EventArgs e)
        {
            var rntForm = new RentReturn();
            Nav(rntForm,contentPanel);
        }
    }
}

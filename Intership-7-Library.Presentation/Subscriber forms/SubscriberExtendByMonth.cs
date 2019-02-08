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
using Internship_7_Library.Domain.Repositories;
using Internship_7_Library.Domain.Repositories.Member;
using Environment = System.Environment;

namespace Intership_7_Library.Presentation.Subscriber_forms
{
    public partial class SubscriberExtendByMonth : Form
    {
        private readonly PersonRepo _personRepo;
        private readonly SubscriberRepo _subscriberRepo;
        private MatchCollection _personMatches;
        private DateTime _personDateOfBirth;
        public SubscriberExtendByMonth()
        {
            _personRepo = new PersonRepo();
            _subscriberRepo = new SubscriberRepo(_personRepo);
            InitializeComponent();
            AdjustList();
        }

        private void AdjustList()
        {
            listOfMembers.Items.Clear();
            foreach (var subscriber in _subscriberRepo.GetAllSubscriber().Where(sub => sub.Person.Surname.Contains(memberSearchTextBox.Text)))
            {
                listOfMembers.Items.Add($"{subscriber.Person.Name} {subscriber.Person.Surname} {subscriber.Person.DateOfBirth.Value.ToString("dd/MM/yyyy")}" +
                                        $" \n Model: {subscriber.TypeSubscription.Category}" +
                                        $" \n Last renewal: {subscriber.DateOfRenewal.ToString("dd/MM/yyyy")}");
            }
        }
        private void memberSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustList();
        }

        private void listOfMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOfMembers.SelectedIndices.Count == 0) return;
            var parseStringBeforeSpace = new Regex(@"[^\s]+");
            _personMatches = parseStringBeforeSpace.Matches(listOfMembers.SelectedItems[0].Text);
            _personDateOfBirth = DateTime.ParseExact(_personMatches[2].Value, "dd/MM/yyyy", null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            var subscriberPicked = _subscriberRepo.GetSubscriberByNameSurnameBirth(_personMatches[0].Value,
                _personMatches[1].Value, _personDateOfBirth);
            _subscriberRepo.ExtendSubscriptionByMonth(subscriberPicked.SubscriberId);
            memberSearchTextBox.Text = "";
            AdjustList();
        }
    }
}

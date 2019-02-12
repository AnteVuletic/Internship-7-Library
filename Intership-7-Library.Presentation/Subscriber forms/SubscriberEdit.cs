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
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Subscriber_forms
{
    public partial class SubscriberEdit : Form
    {
        private readonly SubscriberRepo _subscriberRepo;
        private readonly SubscriptionRepo _subscriptionRepo;
        private int _index;
        private bool _firstIteration;
        public SubscriberEdit()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _subscriberRepo = new SubscriberRepo(personRepo);
            _subscriptionRepo = new SubscriptionRepo();
            _index = 0;
            _firstIteration = true;
            SetData();
        }
        private bool SetData()
        {
            if (_firstIteration)
            {
                foreach (var allSubscriptionType in _subscriptionRepo.GetAllSubscriptionTypes())
                {
                    typeSubCombo.Items.Add(allSubscriptionType.Category);
                }

                _firstIteration = false;
            }
            if (_subscriberRepo.GetAllSubscriber().Count == 0)
            {
                MessageBox.Show("No subscriber has been added yet", "Subscriber not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                typeSubCombo.Text = "";
                dateOfRenewalPicker.Value = DateTime.Now;
                btnSave.Enabled = false;
            }

            if (_subscriberRepo.GetAllSubscriber().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _subscriberRepo.GetAllSubscriber()[_index].Person.Name;
            surnameTextBox.Text = _subscriberRepo.GetAllSubscriber()[_index].Person.Surname;
            dateOfBirthPicker.Value = _subscriberRepo.GetAllSubscriber()[_index].Person.DateOfBirth.Value;
            typeSubCombo.Text = _subscriberRepo.GetAllSubscriber()[_index].TypeSubscription.Category;
            dateOfRenewalPicker.Value = _subscriberRepo.GetAllSubscriber()[_index].DateOfRenewal;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBoxParser.TextBoxChecker(Controls);
            if (!_subscriberRepo.EditSubscriber(_subscriberRepo.GetAllSubscriber()[_index].SubscriberId,
                nameTextBox.Text,
                surnameTextBox.Text, dateOfBirthPicker.Value, dateOfRenewalPicker.Value,
                _subscriptionRepo.GetSubscriptionByCategory(typeSubCombo.Text)))
            {
                MessageBox.Show("This person is already an subscriber", "Subscriber exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
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

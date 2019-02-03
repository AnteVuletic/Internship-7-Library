using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Subscriber_forms
{
    public partial class SubscriberAdd : Form
    {
        private readonly SubscriberRepo _subscriberRepo;
        private readonly SubscriptionRepo _subscriptionRepo;
        private bool _firstIteration;
        public SubscriberAdd(SubscriptionRepo subscriptionRepo, SubscriberRepo subscriberRepo)
        {
            InitializeComponent();
            _subscriptionRepo = subscriptionRepo;
            _subscriberRepo = subscriberRepo;
            _firstIteration = true;
            NewForm();
        }

        public void NewForm()
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            typeSubCombo.Text = "";
            dateOfBirthPicker.MaxDate = new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day);
            dateOfBirthPicker.Value =
                new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day - 2);
            if (!_firstIteration) return;
            foreach (var allSubscriptionType in _subscriptionRepo.GetAllSubscriptionTypes())
            {
                typeSubCombo.Items.Add(allSubscriptionType.Category);
            }

            _firstIteration = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _subscriberRepo.AddSubscriber(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,DateTime.Today,
                _subscriptionRepo.GetSubscriptionByCategory(typeSubCombo.Text));
            NewForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

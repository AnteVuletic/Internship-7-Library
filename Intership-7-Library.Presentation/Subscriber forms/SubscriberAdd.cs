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
    public partial class SubscriberAdd : Form
    {
        private readonly SubscriberRepo _subscriberRepo;
        private readonly SubscriptionRepo _subscriptionRepo;
        private bool _firstIteration;
        public SubscriberAdd()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _subscriptionRepo = new SubscriptionRepo();
            _subscriberRepo = new SubscriberRepo(personRepo);
            _firstIteration = true;
            NewForm();
        }

        public void NewForm()
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            typeSubCombo.SelectedIndex = -1;
            dateOfBirthPicker.MaxDate = new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day);
            dateOfBirthPicker.Value =
                new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day - 2);
            if (!_firstIteration) return;
            var allSubscriptionTypes = _subscriptionRepo.GetAllSubscriptionTypes();
            if (allSubscriptionTypes.Count == 0)
            {
                MessageBox.Show("Please add an subscription model before adding an subscriber",
                    "Subscription model not exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            foreach (var allSubscriptionType in allSubscriptionTypes)
            {
                typeSubCombo.Items.Add(allSubscriptionType.Category);
            }

            _firstIteration = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmptyChecker.TryTextFieldsEmpty(Controls))
            {
                MessageBox.Show("Please make sure you enter a value for all text fields", "Value empty error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TextBoxParser.TextBoxChecker(Controls);
            if (typeSubCombo.Text == "")
            {
                MessageBox.Show("Please choose an subscription model before pressing save.", "Subscription model empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_subscriberRepo.AddSubscriber(nameTextBox.Text, surnameTextBox.Text, dateOfBirthPicker.Value,
                DateTime.Today,
                _subscriptionRepo.GetSubscriptionByCategory(typeSubCombo.Text)))
            {
                MessageBox.Show("This person is already an subscriber", "Subscriber exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            NewForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

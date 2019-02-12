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

namespace Intership_7_Library.Presentation.Subscription_forms
{
    public partial class SubscriptionAdd : Form
    {
        private readonly SubscriptionRepo _subscriptionRepo;
        public SubscriptionAdd()
        {
            InitializeComponent();
            _subscriptionRepo = new SubscriptionRepo();
        }

        public void NewForm()
        {
            catNameTextBox.Text = "";
            priceTextBox.Text = "";
            bookLimitTextBox.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBoxParser.TextBoxChecker(Controls);
            if (!_subscriptionRepo.AddSubscription(catNameTextBox.Text, int.Parse(bookLimitTextBox.Text),
                int.Parse(priceTextBox.Text)))
            {
                MessageBox.Show("Subscription category has been already added", "Subscription exists error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

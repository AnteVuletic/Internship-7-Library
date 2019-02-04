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
    public partial class SubscriptionEdit : Form
    {
        private readonly SubscriptionRepo _subscriptionRepo;
        private int _index;
        public SubscriptionEdit()
        {
            InitializeComponent();
            _subscriptionRepo = new SubscriptionRepo();
            _index = 0;
            SetData();
        }
        private bool SetData()
        {
            if (_subscriptionRepo.GetAllSubscriptionTypes().Count == 0)
            {
                catNameTextBox.Text = "";
                bookLimitTextBox.Text = "";
                priceTextBox.Text = "";
            }

            if (_subscriptionRepo.GetAllSubscriptionTypes().Count <= _index || _index < 0) return false;
            catNameTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].Category;
            bookLimitTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].BookLimitAtOnce.ToString();
            priceTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].PricePerMonth.ToString();
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _subscriptionRepo.EditSubscription(_subscriptionRepo.GetAllSubscriptionTypes()[_index].SubscriptionId,
                catNameTextBox.Text, int.Parse(bookLimitTextBox.Text), int.Parse(priceTextBox.Text));
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

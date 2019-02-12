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
                MessageBox.Show("No subscription model has been added yet.", "Subscription model not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                catNameTextBox.Text = "";
                bookLimitTextBox.Text = "";
                priceTextBox.Text = "";
                btnSave.Enabled = false;
            }

            if (_subscriptionRepo.GetAllSubscriptionTypes().Count <= _index || _index < 0) return false;
            catNameTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].Category;
            bookLimitTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].BookLimitAtOnce.ToString();
            priceTextBox.Text = _subscriptionRepo.GetAllSubscriptionTypes()[_index].PricePerMonth.ToString();
            return true;
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
            if (!_subscriptionRepo.EditSubscription(_subscriptionRepo.GetAllSubscriptionTypes()[_index].SubscriptionId,
                catNameTextBox.Text, int.Parse(bookLimitTextBox.Text), int.Parse(priceTextBox.Text)))
            {
                MessageBox.Show("Subscription category with this name already exists",
                    "Subscription model exists error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void bookLimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}

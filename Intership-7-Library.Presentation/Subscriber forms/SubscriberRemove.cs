using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Domain.Repositories;
using Internship_7_Library.Domain.Repositories.Member;

namespace Intership_7_Library.Presentation.Subscriber_forms
{
    public partial class SubscriberRemove : Form
    {
        private readonly SubscriberRepo _subscriberRepo;
        private int _index;
        public SubscriberRemove()
        {
            InitializeComponent();
            var personRepo = new PersonRepo();
            _subscriberRepo = new SubscriberRepo(personRepo);
            _index = 0;
            SetData();
        }

        private bool SetData()
        {
            if (_subscriberRepo.GetAllSubscriber().Count == 0)
            {
                MessageBox.Show("No subscriber has been added yet", "Subscriber not exists error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                dateOfBirthPicker.Value = DateTime.Now;
                typeSubCombo.Text = "";
                dateOfRenewalPicker.Value = DateTime.Now;
                btnDelete.Enabled = false;
            }

            if (_subscriberRepo.GetAllSubscriber().Count <= _index || _index < 0) return false;
            nameTextBox.Text = _subscriberRepo.GetAllSubscriber()[_index].Person.Name;
            surnameTextBox.Text = _subscriberRepo.GetAllSubscriber()[_index].Person.Surname;
            dateOfBirthPicker.Value = _subscriberRepo.GetAllSubscriber()[_index].Person.DateOfBirth.Value;
            typeSubCombo.Text = _subscriberRepo.GetAllSubscriber()[_index].TypeSubscription.Category;
            dateOfRenewalPicker.Value = _subscriberRepo.GetAllSubscriber()[_index].DateOfRenewal;
            return true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_subscriberRepo.RemoveSubscriber(_subscriberRepo.GetAllSubscriber()[_index].SubscriberId))
            {
                MessageBox.Show("Cannot remove subscriber who currently has an book rented", "Rent error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _index = 0;
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

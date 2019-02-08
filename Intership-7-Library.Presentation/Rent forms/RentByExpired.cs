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

namespace Intership_7_Library.Presentation.Rent_forms
{
    public partial class RentByExpired : Form
    {
        private readonly SubscriberRepo _subscriberRepo;
        private readonly PersonRepo _personRepo;
        public RentByExpired()
        {
            _personRepo = new PersonRepo();
            _subscriberRepo = new SubscriberRepo(_personRepo);
            InitializeComponent();
            foreach (var sub in _subscriberRepo.GetAllSubscriber().Where(sub => (DateTime.Now.Date - sub.DateOfRenewal) > new TimeSpan(30, 0, 0, 0)
                                                                                && sub.Person.Rents.Count(rnt => rnt.PersonId == sub.Person.PersonId
                                                                                                                 && !rnt.ReturnDate.HasValue) != 0))
            {
                expiredWithBookListView.Items.Add($"{sub.Person.Name} {sub.Person.Surname}").BackColor = Color.IndianRed;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

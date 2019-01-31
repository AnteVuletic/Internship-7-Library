using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        public Person Person { get; set; }
        public int MonthlyBookLimit { get; set; }
        public DateTime DateOfRenewal { get; set; }
        public Subscription TypeSubscription { get; set; }

    }
}

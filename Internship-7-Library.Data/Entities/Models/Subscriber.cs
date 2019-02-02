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
        public DateTime DateOfRenewal { get; set; }
        public Subscription TypeSubscription { get; set; }

        public Subscriber()
        {
            
        }
        public Subscriber(Person person, DateTime dateOfRenewal,Subscription typeSubscription)
        {
            Person = person;
            DateOfRenewal = dateOfRenewal;
            TypeSubscription = typeSubscription;
        }

    }
}

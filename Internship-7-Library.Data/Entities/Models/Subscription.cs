using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Category { get; set; }
        public int BookLimitAtOnce { get; set; }
        public int PricePerMonth { get; set; }
        public ICollection<Subscriber> Subscribers { get; set; }

        public Subscription(string category, int bookLimitAtOnce, int pricePerMonth)
        {
            Category = category;
            BookLimitAtOnce = bookLimitAtOnce;
            PricePerMonth = pricePerMonth;
        }
    }
}

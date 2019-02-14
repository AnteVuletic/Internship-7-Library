using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Member
{
    public class SubscriptionRepo
    {
        private readonly Context _context;

        public SubscriptionRepo()
        {
            _context = new Context();
        }

        public Subscription GetSubscription(int subscriptionId)
        {
            return _context.Subscriptions.Find(subscriptionId);
        }

        public Subscription GetSubscriptionByCategory(string category)
        {
            return _context.Subscriptions.First(sub => sub.Category == category);
        }
        public List<Subscription> GetAllSubscriptionTypes()
        {
            return _context.Subscriptions.ToList();
        }

        public bool AddSubscription(string category, int bookLimitAtOnce, int pricePerMonth)
        {
            if (_context.Subscriptions.Any(sub => sub.Category == category)) return false;
            _context.Subscriptions.Add(new Subscription(category, bookLimitAtOnce, pricePerMonth));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveSubscription(int subscriptionId)
        {
            var subFound = GetSubscription(subscriptionId);
            if (subFound == null) return false;
            if (_context.Subscribers.Any(sub =>
                    sub.TypeSubscription.SubscriptionId == subFound.SubscriptionId)) return false;
            _context.Subscriptions.Remove(_context.Subscriptions.Find(subFound.SubscriptionId));
            _context.SaveChanges();
            return true;
        }

        public bool EditSubscription(int subscriptionId, string category, int bookLimitAtOnce, int pricePerMonth)
        {
            var subFound = GetSubscription(subscriptionId);
            if (subFound == null) return false;
            if (_context.Subscriptions.Count(sub => sub.Category == category) >= 1) return false;
            subFound.Category = category;
            subFound.BookLimitAtOnce = bookLimitAtOnce;
            subFound.PricePerMonth = pricePerMonth;
            _context.SaveChanges();
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Library.Domain.Repositories.Member
{
    public class SubscriberRepo
    {
        private readonly Context _context;
        private readonly PersonRepo _personRepo;

        public SubscriberRepo(PersonRepo personRepo)
        {
            _context = new Context();
            _personRepo = personRepo;
        }

        public Subscriber GetSubscriber(int subscriberId)
        {
            return _context.Subscribers.Find(subscriberId);
        }

        public Subscriber GetSubscriberByNameSurnameBirth(string name, string surname,DateTime dateOfBirth)
        {
            return _context.Subscribers.FirstOrDefault(sub =>
                sub.Person.Name == name && sub.Person.Surname == surname &&
                sub.Person.DateOfBirth.Value == dateOfBirth);
        }
        public List<Subscriber> GetAllSubscriber()
        {
            return _context.Subscribers.Include(sub => sub.Person).ThenInclude(prsn => prsn.Rents).Include(sub => sub.TypeSubscription).ToList();
        }

        public bool AddSubscriber(string name,string surname,DateTime dateOfBirth, DateTime dateOfRenewal,Subscription subType )
        {
            var personSubscriber = new Person(name, surname, dateOfBirth);
            if (!_personRepo.AddPerson(personSubscriber)) return false;
            _context.Subscribers.Add(new Subscriber(_context.Persons.Find(personSubscriber.PersonId), dateOfRenewal, _context.Subscriptions.Find(subType.SubscriptionId)));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveSubscriber(int subscriberId)
        {
            var subscriberFound = GetSubscriber(subscriberId);
            if (subscriberFound == null) return false;
            if (_context.Rents.Any(rnt =>
                rnt.Person.PersonId == subscriberFound.Person.PersonId && !rnt.ReturnDate.HasValue)) return false;
            _context.Remove(subscriberFound);
            _context.Persons.Remove(
                _context.Persons.FirstOrDefault(prsn => prsn.PersonId == subscriberFound.Person.PersonId));
            _context.SaveChanges();
            return true;
        }

        public bool EditSubscriber(int subscriberId,string name,string surname,DateTime dateOfBirth,DateTime dateOfRenewal,Subscription subType)
        {
            var subscriberFound = GetSubscriber(subscriberId);
            if (subscriberFound == null) return false;
            if (_context.Subscribers.Count(sub =>
                sub.Person.Name == name && sub.Person.Surname == surname &&
                sub.Person.DateOfBirth.Value == dateOfBirth) > 1) return false;
            subscriberFound.Person.Name = name;
            subscriberFound.Person.Surname = surname;
            subscriberFound.Person.DateOfBirth = dateOfBirth;
            subscriberFound.DateOfRenewal = dateOfRenewal;
            subscriberFound.TypeSubscription = _context.Subscriptions.FirstOrDefault(sub => sub.Category == subType.Category);
            _context.SaveChanges();
            return true;
        }

        public bool ExtendSubscriptionByMonth(int subscriberId)
        {
            var subscriberFound = GetSubscriber(subscriberId);
            if (subscriberFound == null) return false;
            subscriberFound.DateOfRenewal = subscriberFound.DateOfRenewal +
                                            new TimeSpan(DateTime.DaysInMonth(subscriberFound.DateOfRenewal.Year,
                                                subscriberFound.DateOfRenewal.Month),0,0,0);
            _context.SaveChanges();
            return true;
        }
    }
}

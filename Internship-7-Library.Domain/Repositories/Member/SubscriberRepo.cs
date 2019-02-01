using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

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

        public List<Subscriber> GetAllSubscriber()
        {
            return _context.Subscribers.ToList();
        }

        public bool AddSubscriber(string name,string surname,DateTime dateOfBirth, DateTime dateOfRenewal,Subscription subType )
        {
            var personSubscriber = new Person(name, surname, dateOfBirth);
            if (!_personRepo.AddPerson(personSubscriber)) return false;
            _context.Subscribers.Add(new Subscriber(personSubscriber, dateOfRenewal, subType));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveSubscriber(int subscriberId)
        {
            var subscriberFound = GetSubscriber(subscriberId);
            if (subscriberFound == null) return false;
            _personRepo.RemovePerson(subscriberFound.Person.PersonId);
            _context.Remove(subscriberFound);
            _context.SaveChanges();
            return true;
        }

        public bool EditSubscriber(int subscriberId,string name,string surname,DateTime dateOfBirth,DateTime dateOfRenewal,Subscription subType)
        {
            var subscriberFound = GetSubscriber(subscriberId);
            if (subscriberFound == null) return false;
            subscriberFound.Person.Name = name;
            subscriberFound.Person.Surname = surname;
            subscriberFound.Person.DateOfBirth = dateOfBirth;
            subscriberFound.DateOfRenewal = dateOfRenewal;
            subscriberFound.TypeSubscription = subType;
            _context.SaveChanges();
            return true;
        }
    }
}

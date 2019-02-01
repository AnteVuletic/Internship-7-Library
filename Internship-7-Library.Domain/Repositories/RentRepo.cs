using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories
{
    public class RentRepo
    {
        private readonly Context _context;

        public RentRepo()
        {
            _context = new Context();
        }

        public List<Rent> GetAllCurrentlyRented()
        {
            return _context.Rents.Where(rnt => rnt.ReturnDate == null).ToList();
        }

        public bool RentBook(Data.Entities.Models.Book book, Person person)
        {
            if (_context.Rents.Any(rnt => rnt.Book == book && rnt.Person == person && rnt.ReturnDate == null))
                return false;
            _context.Rents.Add(new Rent(person,book, DateTime.Now));
            _context.SaveChanges();
            return true;
        }

        public bool BookReturned(Data.Entities.Models.Book book, Person person)
        {
            var rentedBook = _context.Rents.FirstOrDefault(rnt => rnt.Book == book && rnt.Person == person && rnt.ReturnDate == null);
            if (rentedBook == null) return false;
            rentedBook.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public IQueryable<Rent> AllBooksRentedBySubscribersWithExpiredSub(TimeSpan timeForExpiring)
        {
            return _context.Rents.Where(rnt =>
                rnt.Person.Subscribers.ToList().Count != 0 && rnt.Person.Subscribers.Where(sub => sub.DateOfRenewal - DateTime.Now < timeForExpiring).ToList().Count != 0);
        }
    }
}

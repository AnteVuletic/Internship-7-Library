using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime StartOfRent { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Rent()
        {
            
        }
        public Rent(Person person, Book book, DateTime startOfRent)
        {
            Person = person;
            Book = book;
            StartOfRent = startOfRent;
        }
    }
}

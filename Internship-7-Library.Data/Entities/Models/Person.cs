using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public ICollection<Member> InstitutionMembers { get; set; }
        public ICollection<Subscriber> Subscribers { get; set; }
        public ICollection<Rent> Rents { get; set; }

        public Person(string name, string surname, DateTime? dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
    }
}

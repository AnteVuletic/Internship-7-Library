using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Library.Domain.Repositories
{
    public class PersonRepo
    {
        private readonly Context _context;

        public PersonRepo()
        {
            _context = new Context();
        }

        public Person GetPerson(int personId)
        {
            return _context.Persons.Find(personId);
        }

        public Person GetPersonByNameSurnameDate(string name, string surname,DateTime dateOfBirth)
        {
            return _context.Persons.FirstOrDefault(prsn => prsn.Name == name && prsn.Surname == surname && prsn.DateOfBirth == dateOfBirth);
        }
        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }
        public List<Person> GetAllPersonsDetails()
        {
            return _context.Persons.Include(prsn => prsn.InstitutionMembers).Include(prsn => prsn.Subscribers).Include(prsn => prsn.Rents).ThenInclude(rnts => rnts.Book).ToList();
        }

        public bool AddPerson(string name, string surname,DateTime? dateOfBirth)
        {
            if (_context.Persons.Any(prsn =>
                prsn.Name == name && prsn.Surname == surname && prsn.DateOfBirth == dateOfBirth)) return false;
            _context.Persons.Add(new Person(name, surname, dateOfBirth));
            _context.SaveChanges();
            return true;
        }
        public bool AddPerson(Person personToAdd)
        {
            if (_context.Persons.Any(prsn =>
                prsn.Name == personToAdd.Name && prsn.Surname == personToAdd.Surname &&
                prsn.DateOfBirth == personToAdd.DateOfBirth)) return false;
            _context.Persons.Add(personToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool RemovePerson(int personId)
        {
            var personFound = GetPerson(personId);
            if (personFound == null) return false;
            _context.Persons.Remove(_context.Persons.Find(personId));
            _context.SaveChanges();
            return true;
        }

        public bool EditPerson(int personId, string name, string surname, DateTime dateOfBirth)
        {
            return RemovePerson(personId) && AddPerson(name, surname, dateOfBirth);
        }
    }
}

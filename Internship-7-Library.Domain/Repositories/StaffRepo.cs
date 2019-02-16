using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Internship_7_Library.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Library.Domain.Repositories
{
    public class StaffRepo
    {
        public readonly Context _context;
        public readonly PersonRepo _personRepo;
        public StaffRepo(PersonRepo personRepo)
        {
            _context = new Context();
            _personRepo = personRepo;
        }

        public Staff GetStaff(int staffId)
        {
            return _context.Staff.Find(staffId);
        }

        public List<Staff> GetAllStaff()
        {
            return _context.Staff.Include(stf => stf.Person).ToList();
        }

        public bool AddStaff(string name, string surname,DateTime dateOfBirth, StaffPosition position )
        {
            var staffPerson = new Person(name,surname,dateOfBirth);
            if (!_personRepo.AddPerson(staffPerson)) return false;
            _context.Staff.Add(new Staff(_context.Persons.Find(staffPerson.PersonId), position));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveStaff(int staffId)
        {
            var staffFound = GetStaff(staffId);
            if (staffFound == null) return false;
            _context.Staff.Remove(staffFound);
            _context.Persons.Remove(_context.Persons.Find(staffFound.Person.PersonId));
            _context.SaveChanges();
            return true;
        }

        public bool EditStaff(int staffId, string name, string surname, DateTime dateOfBirth, StaffPosition position)
        {
            var staffFound = GetStaff(staffId);
            if (staffFound == null) return false;
            if (_context.Staff.Count(stff =>
                stff.Person.Name == name && stff.Person.Surname == surname &&
                stff.Person.DateOfBirth.Value == dateOfBirth && stff.StaffId != staffId) >= 1) return false;
            staffFound.Person.Name = name;
            staffFound.Person.Surname = surname;
            staffFound.Person.DateOfBirth = dateOfBirth;
            staffFound.Position = position;
            _context.SaveChanges();
            return true;
        }
    }
}

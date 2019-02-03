﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Member
{
    public class MemberRepo
    {
        private readonly Context _context;
        private readonly PersonRepo _personRepo;

        public MemberRepo(PersonRepo personRepo)
        {
            _context = new Context();
            _personRepo = personRepo;
        }

        public Data.Entities.Models.Member GetMember(int memberId)
        {
            return _context.Members.Find(memberId);
        }

        public List<Data.Entities.Models.Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public bool AddMember(string name, string surname, DateTime dateOfBirth, bool professor, Institution institution)
        {
            var memberPerson = new Person(name,surname,dateOfBirth);
            if (!_personRepo.AddPerson(memberPerson)) return false;
            _context.Members.Add(new Data.Entities.Models.Member(_context.Persons.Find(memberPerson.PersonId),professor,_context.Institutions.Find(institution.InstitutionId)));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveMember(int memberId)
        {
            var memberFound = GetMember(memberId);
            if (memberFound == null) return false;
            _personRepo.RemovePerson(memberFound.Person.PersonId);
            _context.Members.Remove(memberFound);
            return true;
        }

        public bool EditMember(int memberId, string name, string surname, DateTime dateOfBirth, bool professor,
            Institution institution)
        {
            var memberFound = GetMember(memberId);
            if (memberFound == null) return false;
            memberFound.Person.Name = name;
            memberFound.Person.Surname = surname;
            memberFound.Professor = professor;
            memberFound.Institution = institution;
            _context.SaveChanges();
            return true;
        }
    }
}
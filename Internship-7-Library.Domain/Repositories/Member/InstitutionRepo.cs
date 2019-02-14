using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Member
{
    public class InstitutionRepo
    {
        public readonly Context _context;

        public InstitutionRepo()
        {
            _context = new Context();
        }

        public Institution GetInstitution(int institutionId)
        {
            return _context.Institutions.Find(institutionId);
        }

        public Institution GetInstitutionByName(string instName)
        {
            return _context.Institutions.First(inst => inst.Name == instName);
        }
        public List<Institution> GetAllInstitutions()
        {
            return _context.Institutions.ToList();
        }

        public bool AddInstitution(string name, string address)
        {
            if (_context.Institutions.Any(inst => inst.Name == name)) return false;
            _context.Institutions.Add(new Institution(name, address));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveInstitution(int institutionId)
        {
            var institutionFound = GetInstitution(institutionId);
            if (institutionFound == null) return false;
            if (_context.Members.Any(memb => memb.Institution.InstitutionId == institutionFound.InstitutionId)) return false;
            _context.Institutions.Remove(institutionFound);
            _context.SaveChanges();
            return true;
        }

        public bool EditInstitution(int institutionId, string name, string address)
        {
            var institutionFound = GetInstitution(institutionId);
            if (institutionFound == null) return false;
            if (_context.Institutions.Count(inst => inst.Name == name) >= 1) return false;
            institutionFound.Name = name;
            institutionFound.Address = address;
            _context.SaveChanges();
            return true;
        }
    }
}

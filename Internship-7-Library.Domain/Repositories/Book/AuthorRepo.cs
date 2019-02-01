using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class AuthorRepo
    {
        private readonly Context _context;
        private readonly PersonRepo _personRepo;
        public AuthorRepo(PersonRepo personRepo)
        {
            _context = new Context();
            _personRepo = personRepo;
        }

        public Author GetAuthor(int authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public bool AddAuthor(string name, string surname)
        {
            var authorPerson = new Person(name,surname,default(DateTime));
            if (!_personRepo.AddPerson(authorPerson)) return false;
            _context.Authors.Add(new Author(authorPerson));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveAuthor(int authorId)
        {
            var authorFound = _context.Authors.Find(authorId);
            if (authorFound == null) return false;
            _personRepo.RemovePerson(authorFound.Person.PersonId);
            _context.Authors.Remove(authorFound);
            _context.SaveChanges();
            return true;

        }

        public bool EditAuthor(int authorId, string name, string surname)
        {
            var authorFound = GetAuthor(authorId);
            if (authorFound == null) return false;
            authorFound.Person.Name = name;
            authorFound.Person.Surname = surname;
            _context.SaveChanges();
            return true;
        }
    }
}

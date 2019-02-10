using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public Author GetAuthorByName(string authorFullname)
        {
            var regName = new Regex(@"[^\s]+");
            var matchAuthor = regName.Matches(authorFullname);
            return _context.Authors.First(ath => ath.AuthorPerson.Name == matchAuthor[0].Value && ath.AuthorPerson.Surname == matchAuthor[1].Value);
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.Include(ath => ath.AuthorPerson).ToList();
        }

        public bool AddAuthor(string name, string surname)
        {
            var authorPerson = new Person(name,surname,default(DateTime));
            if (!_personRepo.AddPerson(authorPerson)) return false;
            _context.Authors.Add(new Author(_context.Persons.Find(authorPerson.PersonId)));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveAuthor(int authorId)
        {
            var authorFound = _context.Authors.Find(authorId);
            if (authorFound == null) return false;
            if (_context.TypeBooks.Any(tybk => tybk.AuthorInfo.AuthorId == authorId)) return false;
            _context.Authors.Remove(_context.Authors.Find(authorId));
            _context.Persons.Remove(_context.Persons.First(prsn => prsn.PersonId == authorFound.AuthorPerson.PersonId));
            _context.SaveChanges();
            return true;

        }

        public bool EditAuthor(int authorId, string name, string surname)
        {
            var authorFound = GetAuthor(authorId);
            if (authorFound == null) return false;
            if (_context.Authors.Any(auth => auth.AuthorPerson.Name == name && auth.AuthorPerson.Surname == surname))
                return false;
            authorFound.AuthorPerson.Name = name;
            authorFound.AuthorPerson.Surname = surname;
            _context.SaveChanges();
            return true;
        }
    }
}

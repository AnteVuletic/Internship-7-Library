﻿using System;
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

        public Author GetAuthorByName(string authorName)
        {
            return _context.Authors.First(ath => ath.AuthorPerson.Name == authorName);
        }

        public List<Person> GetAllAuthors()
        {
            return _context.Authors.Select(ath => ath.AuthorPerson).ToList();
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
            _personRepo.RemovePerson(authorFound.AuthorPerson.PersonId);
            _context.Authors.Remove(authorFound);
            _context.SaveChanges();
            return true;

        }

        public bool EditAuthor(int authorId, string name, string surname)
        {
            var authorFound = GetAuthor(authorId);
            if (authorFound == null) return false;
            authorFound.AuthorPerson.Name = name;
            authorFound.AuthorPerson.Surname = surname;
            _context.SaveChanges();
            return true;
        }
    }
}

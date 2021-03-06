﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Internship_7_Library.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class TypeBookRepo
    {
        private readonly Context _context;
        private readonly BookRepo _bookRepo;
        public TypeBookRepo(BookRepo bookRepo)
        {
            _context = new Context();
            _bookRepo = bookRepo;
        }

        public TypeBook GetBookType(int typeBookId)
        {
            return _context.TypeBooks.Find(typeBookId);
        }

        public TypeBook GetBookTypeByTitle(string title)
        {
            return _context.TypeBooks.FirstOrDefault(typBk => typBk.Title == title);
        }
        public List<TypeBook> GetAllBookTypes()
        {
            return _context.TypeBooks.Include(tybk => tybk.Genre).Include(tybk => tybk.AuthorInfo.AuthorPerson).Include(tybk => tybk.Publisher).Include(tybk => tybk.PhysicalBooks).Include(tybk => tybk.PhysicalBooks).ThenInclude(bk => bk.Rents).ToList();
        }

        public bool AddBooks(string title, string numPages, Genre genre, Author author, Publisher publisher, int numberOfCopies)
        {
            if (_context.TypeBooks.Any(typbk => typbk.Title == title && typbk.Publisher.Name == publisher.Name)) return false;
            var bookInfo = new TypeBook(title, numPages, _context.Genres.Find(genre.GenreId), _context.Authors.Find(author.AuthorId), _context.Publishers.Find(publisher.PublisherId));
            _context.TypeBooks.Add(bookInfo);
            _context.SaveChanges();
            for (var copy = 0; copy < numberOfCopies; copy++)
            {
                _bookRepo.AddBook(bookInfo);
            }
            return true;
        }

        public bool RemoveAllBooks(int typeBookId)
        {
            var bookFound = GetBookType(typeBookId);
            if (bookFound == null) return false;
            _context.Books.RemoveRange(_context.Books.Where(bk => bk.BookInfo.TypeBookId == typeBookId));
            _context.TypeBooks.Remove(_context.TypeBooks.Find(typeBookId));
            _context.SaveChanges();
            return true;
        }

        public int EditBook(int typeBookId, string title, string numPages, Genre genre, Author author,
            Publisher publisher,int numberOfCopies)
        {
            var bookFound = GetBookType(typeBookId);
            var copiesOfBook = _context.Books.Count(bk => bk.BookInfo.TypeBookId == bookFound.TypeBookId);
            if (numberOfCopies < 0) return -2;
            if (_context.TypeBooks.Count(typbk => typbk.Title == title && typbk.Publisher.Name == publisher.Name && typbk.TypeBookId != bookFound.TypeBookId) >= 1) return -1;
            if (copiesOfBook != numberOfCopies)
            {
                var difference = copiesOfBook - numberOfCopies;
                if (difference > 0)
                {
                    for (var i = 0; i < difference; i++)
                    {
                        var copyOfBook = _context.Books.FirstOrDefault(bk =>
                            bk.BookInfo.TypeBookId == bookFound.TypeBookId && bk.State == BookState.Available);
                        if (copyOfBook == null)
                            return -4;
                        _context.Books.Remove(copyOfBook);
                        _context.SaveChanges();
                    }
                }

                if (difference < 0)
                {
                    difference *= -1;
                    for (var i = 0; i < difference; i++)
                    {
                        _context.Books.Add(
                            new Data.Entities.Models.Book(_context.TypeBooks.Find(bookFound.TypeBookId)));
                        _context.SaveChanges();
                    }
                }
            }
            if (bookFound == null) return -3;
            bookFound.Title = title;
            bookFound.NumPages = numPages;
            bookFound.Genre = _context.Genres.Find(genre.GenreId);
            bookFound.AuthorInfo = _context.Authors.Find(author.AuthorId);
            bookFound.Publisher = _context.Publishers.Find(publisher.PublisherId);
            _context.SaveChanges();
            return 1;
        }
    }
}

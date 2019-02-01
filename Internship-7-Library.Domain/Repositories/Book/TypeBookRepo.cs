using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class TypeBookRepo
    {
        private readonly Context _context;
        private readonly BookRepo _bookRepo;
        public TypeBookRepo(Context context,BookRepo bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        public TypeBook GetBookType(int typeBookId)
        {
            return _context.TypeBooks.Find(typeBookId);
        }

        public List<TypeBook> GetAllBookTypes()
        {
            return _context.TypeBooks.ToList();
        }

        public bool AddBooks(string title, string numPages, Genre genre, Author author, Publisher publisher, int numberOfCopies)
        {
            if (_context.TypeBooks.Any(typbk => typbk.Title == title)) return false;
            var bookInfo = new TypeBook(title, numPages, genre, author, publisher);
            _context.TypeBooks.Add(bookInfo);
            for (var copy = 0; copy <= numberOfCopies; copy++)
            {
                _bookRepo.AddBook(bookInfo);
            }

            _context.SaveChanges();
            return true;
        }

        public bool RemoveAllBooks(int typeBookId)
        {
            var bookFound = GetBookType(typeBookId);
            if (bookFound == null) return false;
            _bookRepo.RemoveAllBooks(bookFound);
            _context.TypeBooks.Remove(bookFound);
            _context.SaveChanges();
            return true;
        }

        public bool EditBook(int typeBookId, string title, string numPages, Genre genre, Author author,
            Publisher publisher)
        {
            var bookFound = GetBookType(typeBookId);
            if (bookFound == null) return false;
            bookFound.Title = title;
            bookFound.NumPages = numPages;
            bookFound.Genre = genre;
            bookFound.AuthorInfo = author;
            bookFound.Publisher = publisher;
            _context.SaveChanges();
            return true;
        }
    }
}

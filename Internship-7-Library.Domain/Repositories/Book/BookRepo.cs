﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;
using Internship_7_Library.Data.Enums;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class BookRepo
    {
        public readonly Context _context;

        public BookRepo()
        {
            _context = new Context();
        }

        public Data.Entities.Models.Book GetBook(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Data.Entities.Models.Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(TypeBook bookInfo)
        {
            _context.Books.Add(new Data.Entities.Models.Book(_context.TypeBooks.Find(bookInfo.TypeBookId)));
            _context.SaveChanges();
        }

        public bool MarkRuined(TypeBook bookInfo)
        {
            var physicalBookCopyFound = _context.Books.FirstOrDefault(bk => bk.BookInfo == bookInfo && bk.State == BookState.Available);
            if (physicalBookCopyFound == null) return false;
            physicalBookCopyFound.State = BookState.Ruined;
            _context.SaveChanges();
            return true;
        }

        public bool MarkLost(TypeBook bookInfo)
        {
            var physicalBookCopyFound =
                _context.Books.FirstOrDefault(bk => bk.BookInfo == bookInfo && bk.State == BookState.Available);
            if (physicalBookCopyFound == null) return false;
            physicalBookCopyFound.State = BookState.Lost;
            _context.SaveChanges();
            return true;
        }

    }
}

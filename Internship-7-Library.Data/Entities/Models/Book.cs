using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Enums;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public TypeBook BookInfo { get; set; }
        public BookState State { get; set; }
        public ICollection<Rent> Rents { get; set; }

        public Book(TypeBook bookInfo)
        {
            BookInfo = bookInfo;
            State = BookState.Available;
        }
    }
}

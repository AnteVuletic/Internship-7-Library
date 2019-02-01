using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class TypeBook
    {
        public int TypeBookId { get; set; }
        public string Title { get; set; }
        public string NumPages { get; set; }
        public Genre Genre { get; set; }
        public Author AuthorInfo { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Book> PhysicalBooks { get; set; }

        public TypeBook(string title, string numPages, Genre genre, Author authorInfo, Publisher publisher)
        {
            Title = title;
            NumPages = numPages;
            Genre = genre;
            AuthorInfo = authorInfo;
            Publisher = publisher;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public Person Person { get; set; }
        public ICollection<TypeBook> BookInfos { get; set; }
    }
}

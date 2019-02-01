using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TypeBook> BookInfos { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}

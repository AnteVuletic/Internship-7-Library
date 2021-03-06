﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<TypeBook> BookInfos { get; set; }

        public Publisher(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}

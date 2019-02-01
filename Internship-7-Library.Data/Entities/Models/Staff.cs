using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Enums;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public Person Person { get; set; }
        public StaffPosition Position { get; set; }

        public Staff(Person person, StaffPosition position)
        {
            Person = person;
            Position = position;
        }
    }
}

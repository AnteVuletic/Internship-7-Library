using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public Person Person { get; set; }
        public bool Professor { get; set; }
        public Institution Institution { get; set; }

        public Member()
        {
            
        }
        public Member(Person person, bool professor, Institution institution)
        {
            Person = person;
            Professor = professor;
            Institution = institution;
        }

    }
}

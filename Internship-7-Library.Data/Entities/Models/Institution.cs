using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_7_Library.Data.Entities.Models
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}

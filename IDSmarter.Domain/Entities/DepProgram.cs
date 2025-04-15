using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class DepProgram
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }

        public ICollection<Student>? Student { get; set; }
        public ICollection<PreRegistration>? PreRegistration { get; set; }
    }
}

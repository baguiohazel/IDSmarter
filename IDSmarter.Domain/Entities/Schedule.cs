using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public  class Schedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }

        public ICollection<InstructorDetail>? InstructorDetail { get; set; }

    }
} 


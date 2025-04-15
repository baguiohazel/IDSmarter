using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        public int ProgramId { get; set; }
        public DepProgram Program { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StrandId { get; set; }
        public Strand Strand { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}

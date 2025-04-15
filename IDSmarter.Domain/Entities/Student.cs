using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }

        public int PreRegistrationId { get; set; }
        public PreRegistration PreRegistration { get; set; }

        public ICollection<StudentDetail>? StudentDetail { get; set; }
        public ICollection<Grades>? Grade { get; set; }
    }
}


namespace IDSmarter.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int Amount { get; set; }
        public int AmountPaid { get; set; }
        public int Balance => Amount - AmountPaid;
        public DateTime PaymentDate { get; set; }
        public string PaymentReference { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }

        public int CourseId { get; set; }
        public Course Courses { get; set; }

        public int PreRegistrationId { get; set; }
        public PreRegistration PreRegistrations { get; set; }
    }
}

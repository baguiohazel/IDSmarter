
namespace IDSmarter.Domain.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TotalStudents { get; set; }

        public int InstructorDetailId { get; set; }
        public InstructorDetail InstructorDetails { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public ICollection<Admin>? Admins { get; set; }
        public ICollection<Dean>? Deans { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }
      
    }
}



namespace IDSmarter.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructors { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }
        public int EnrollmentId { get; set; }
    }
}

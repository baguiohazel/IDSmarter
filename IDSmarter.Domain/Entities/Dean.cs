
namespace IDSmarter.Domain.Entities
{
    public class Dean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TotalStudent { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
    }
}

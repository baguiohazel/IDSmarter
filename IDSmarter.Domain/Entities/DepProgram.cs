
namespace IDSmarter.Domain.Entities
{
    public class DepProgram
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<PreRegistration>? PreRegistrations { get; set; }
    }
}

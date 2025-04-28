
namespace IDSmarter.Domain.Entities
{
    public class InstructorDetail
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public DepProgram Programs { get; set; }
        public int StrandId { get; set; }
        public Strand Strands { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedules { get; set; }
        public int PreRegistrationId { get; set; }
        public PreRegistration PreRegistrations { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
    }
}

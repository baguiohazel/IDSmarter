
namespace IDSmarter.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }
        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public int StrandId { get; set; }
        public Strand Strands { get; set; }
        public int DepProgramId { get; set; }
        public DepProgram Programs { get; set; }

        public int PrelimScore { get; set; }
        public int MidtermScore { get; set; }
        public int PrefinalScore { get; set; }
        public int FinalScore { get; set; }

        public int TermAverage => (PrelimScore + MidtermScore + PrefinalScore + FinalScore) / 4;
    }
}

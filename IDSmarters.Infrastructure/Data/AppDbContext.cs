using Microsoft.EntityFrameworkCore;
using IDSmarter.Domain.Entities;
using System.Linq;

namespace IDSmarters.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; } 
        public DbSet<Course> Course { get; set; }
        public DbSet<Dean> Dean { get; set; }
        public DbSet<DepProgram> DepProgram { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstructorDetail> InstructorDetail { get; set; }
        public DbSet<PreRegistration> PreRegistration { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Strand> Strand { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentDetail> StudentDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Students)
                .WithMany()
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Dean)
                .WithMany()
                .HasForeignKey(a => a.DeanId);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Instructors)
                .WithMany()
                .HasForeignKey(a => a.InstructorId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Students)
                .WithMany()
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructors)
                .WithMany()
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Enrollments)
                .WithMany()
                .HasForeignKey(c => c.EnrollmentId);

            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Students)
                .WithMany()
                .HasForeignKey(d => d.StudentId);

            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Instructors)
                .WithMany()
                .HasForeignKey(d => d.InstructorId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Courses)
                .WithMany()
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.PreRegistrations)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(e => e.PreRegistrationId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Courses)
                .WithMany()
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Strands)
                .WithMany()
                .HasForeignKey(g => g.StrandId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Programs)
                .WithMany()
                .HasForeignKey(g => g.DepProgramId);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Students)
                .WithMany()
                .HasForeignKey(i => i.StudentId);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.InstructorDetails)
                .WithMany()
                .HasForeignKey(i => i.InstructorDetailId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Programs)
                .WithMany()
                .HasForeignKey(id => id.ProgramId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Strands)
                .WithMany()
                .HasForeignKey(id => id.StrandId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Schedules)
                .WithMany()
                .HasForeignKey(id => id.ScheduleId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.PreRegistrations)
                .WithMany()
                .HasForeignKey(id => id.PreRegistrationId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PreRegistrations)
                .WithMany(pr => pr.Students)
                .HasForeignKey(s => s.PreRegistrationId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Enrollments)
                .WithMany()
                .HasForeignKey(sd => sd.EnrollmentId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Programs)
                .WithMany()
                .HasForeignKey(sd => sd.ProgramId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Courses)
                .WithMany()
                .HasForeignKey(sd => sd.CourseId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Strands)
                .WithMany()
                .HasForeignKey(sd => sd.StrandId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Schedules)
                .WithMany()
                .HasForeignKey(sd => sd.ScheduleId);
        }
    }
}
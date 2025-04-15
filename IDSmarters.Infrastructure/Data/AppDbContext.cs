using Microsoft.EntityFrameworkCore;
using IDSmarter.Domain.Entities;
using System.Linq;

namespace IDSmarters.Infrastructure.Data
{
    internal class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Dean> Dean { get; set; }
        public DbSet<DepProgram> DepProgram { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Grades> Grade { get; set; }
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
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Dean)
                .WithMany()
                .HasForeignKey(a => a.DeanId);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Instructor)
                .WithMany()
                .HasForeignKey(a => a.InstructorId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Student)
                .WithMany()
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Enrollment)
                .WithMany()
                .HasForeignKey(c => c.EnrollmentId);

            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId);

            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Instructor)
                .WithMany()
                .HasForeignKey(d => d.InstructorId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.PreRegistration)
                .WithMany(p => p.Enrollment)
                .HasForeignKey(e => e.PreRegistrationId);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Course)
                .WithMany()
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Strand)
                .WithMany()
                .HasForeignKey(g => g.StrandId);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Program)
                .WithMany()
                .HasForeignKey(g => g.DepProgramId);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Student)
                .WithMany()
                .HasForeignKey(i => i.StudentId);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.InstructorDetail)
                .WithMany()
                .HasForeignKey(i => i.InstructorDetailId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Program)
                .WithMany()
                .HasForeignKey(id => id.ProgramId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Strand)
                .WithMany()
                .HasForeignKey(id => id.StrandId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.Schedule)
                .WithMany()
                .HasForeignKey(id => id.ScheduleId);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(id => id.PreRegistration)
                .WithMany()
                .HasForeignKey(id => id.PreRegistrationId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PreRegistration)
                .WithMany(pr => pr.Student)
                .HasForeignKey(s => s.PreRegistrationId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Enrollment)
                .WithMany()
                .HasForeignKey(sd => sd.EnrollmentId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Program)
                .WithMany()
                .HasForeignKey(sd => sd.ProgramId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Course)
                .WithMany()
                .HasForeignKey(sd => sd.CourseId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Strand)
                .WithMany()
                .HasForeignKey(sd => sd.StrandId);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Schedule)
                .WithMany()
                .HasForeignKey(sd => sd.ScheduleId);
        }
    }
}
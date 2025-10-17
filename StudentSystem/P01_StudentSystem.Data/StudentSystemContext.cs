using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using static P01_StudentSystem.Data.ApplicationCommonConfiguration;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options) :base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
             .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentsCourses)
             .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}

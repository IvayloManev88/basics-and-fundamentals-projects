using System;
using System.Collections.Generic;
using AcademicRecordsApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Data;

public partial class AcademicRecordsDbContext : DbContext
{
    public AcademicRecordsDbContext()
    {
    }

    public AcademicRecordsDbContext(DbContextOptions<AcademicRecordsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; } = null!;

    public virtual DbSet<Grade> Grades { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(
            "Server=.;Database=AcademicRecordsDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exams__3214EC079C5575D8");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(e => e.Course)
            .WithMany(c => c.Exams)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC077368B609");

            entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Exam).WithMany(p => p.Grades)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Exams");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C728B164");

            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {

            entity.HasKey(sc => new { sc.CourseId, sc.StudentId });

            entity.HasOne(sc => sc.Student)
            .WithMany(s => s.Courses)
            .HasForeignKey(sc => sc.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(sc => sc.Course)
           .WithMany(c => c.Students)
           .HasForeignKey(sc => sc.CourseId)
           .OnDelete(DeleteBehavior.Restrict);


        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c=>c.Id);
            entity.Property(c => c.Name)
            .HasMaxLength(100)
            .HasDefaultValue(string.Empty);

           
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

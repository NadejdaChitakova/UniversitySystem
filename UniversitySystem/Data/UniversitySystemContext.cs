using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Model;

namespace UniversitySystem.Data
{
    public class UniversitySystemContext : DbContext
    {
        public UniversitySystemContext (DbContextOptions<UniversitySystemContext> options)
            : base(options)
        {
        }
        public DbSet<UniversitySystem.Model.CourseTopic> CourseTopic { get; set; }
        public DbSet<UniversitySystem.Model.Course> Course { get; set; }
        public DbSet<UniversitySystem.Model.Student> Student { get; set; }
        public DbSet<UniversitySystem.Model.Teacher> Teacher { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<CourseTopic>().ToTable("CourseTopic");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Login>().ToTable("Login");

            modelBuilder.Entity<Enrollment>()
                .HasKey(c => new { c.CourseId, c.StudentId });

            modelBuilder.Entity<Teacher>().HasMany(c => c.Courses).WithOne()
                .HasForeignKey(c => c.TeacherId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CourseTopic>().HasMany(c => c.Courses).WithOne().
                HasForeignKey(c =>c.TopicId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseTopic>().HasData(new CourseTopic { Id = 1 , Topic = "Math"},
                new CourseTopic { Id = 2, Topic = "Computer sciences" });
            modelBuilder.Entity<Login>().HasData(new Login { Id = 1, Username = "Admin", Password = "Admin" });
        }
    }
}


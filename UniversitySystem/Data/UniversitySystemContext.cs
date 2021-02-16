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

        public DbSet<UniversitySystem.Model.Course> Course { get; set; }
        public DbSet<UniversitySystem.Model.Student> Student { get; set; }
        public DbSet<UniversitySystem.Model.Teacher> Teacher { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>()
                .HasKey(c => new { c.CourseId, c.StudentId });

           
        }
    }
}


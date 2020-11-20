using E_LearningSite.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_LearningSite.Data
{
    public class LearningContext : DbContext
    {
        public LearningContext(DbContextOptions<LearningContext> options) : base(options)
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LearningApp",
                b => b.MigrationsAssembly("E-LearningSite.API"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<MentorCatalogue>().HasKey(m => new { m.MentorId, m.CatalogueId });
            modelBuilder.Entity<CourseCatalogue>().HasKey(c => new { c.CourseId, c.CatalogueId });

            modelBuilder.Entity<School>().HasMany(s => s.StudentsList)
                .WithOne(s => s.School).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<School>().HasMany(s => s.CoursesList)
                .WithOne(c => c.School).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<School>().HasMany(s => s.MentorsList)
                .WithOne(m => m.School).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Seed();
        }
    }
}

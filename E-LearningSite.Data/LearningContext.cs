using E_LearningSite.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_LearningSite.Data
{
    public class LearningContext : IdentityDbContext<ApplicationUser>
    {
        public LearningContext(DbContextOptions<LearningContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LearningApp",
                b => b.MigrationsAssembly("E-LearningSite.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorCatalogue>().HasKey(mc => new { mc.MentorId, mc.CatalogueId });
            modelBuilder.Entity<CourseCatalogue>().HasKey(cc => new { cc.CourseId, cc.CatalogueId });

            modelBuilder.Entity<School>().HasMany(s => s.Students)
                .WithOne(s => s.School).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<School>().HasMany(s => s.Courses)
                .WithOne(c => c.School).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<School>().HasMany(s => s.Mentors)
                .WithOne(m => m.School).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<School>().HasMany(s => s.Subjects)
                .WithOne(s => s.School).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<School>().HasMany(s => s.Catalogues)
                .WithOne(c => c.School).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Catalogue>().HasMany(c => c.Students)
                .WithOne(s => s.Catalogue).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Catalogue>().HasMany(c => c.Grades)
                .WithOne(g => g.Catalogue).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>().HasMany(c => c.Documents)
                .WithOne(d => d.Course).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>().HasMany(s => s.Courses)
                .WithOne(c => c.Subject).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();
           
            base.OnModelCreating(modelBuilder);
        }
    }
}

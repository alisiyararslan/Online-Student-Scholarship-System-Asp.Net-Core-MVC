using Microsoft.EntityFrameworkCore;

namespace OnlineStudentScholarshipSystem.Web.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//unique key usage
        {

            modelBuilder.Entity<Student>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Officer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }


        private DbSet<Scholarship> scholarships { get; set; }

        private DbSet<Student> students { get; set; }

        private DbSet<Officer> officers { get; set; }

        private DbSet<Company> companies { get; set; }

        private DbSet<ScholarshipApplication> scholarshipApplications { get; set; }

        public DbSet<Scholarship> Scholarships
        {
            get { return scholarships; }
            set { scholarships = value; }
        }

        public DbSet<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public DbSet<Officer> Officers
        {
            get { return officers; }
            set { officers = value; }
        }

        public DbSet<Company> Companies
        {
            get { return companies; }
            set { companies = value; }
        }

        public DbSet<ScholarshipApplication> ScholarshipApplications
        {
            get { return scholarshipApplications; }
            set { scholarshipApplications = value; }
        }



    }
}

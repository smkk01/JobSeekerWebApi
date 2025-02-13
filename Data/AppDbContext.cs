using CustomersWebApi.Model;
using JobSeekerWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context): base(context)
        {
        
        }
       
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Experience> ExperienceDetail { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<SoftwareExperience> SoftwareExperiences { get; set; }
        public DbSet<LocalUser1> LocalUser1 { get; set; }
        public DbSet<LocalUser> LocalUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
               .HasOne(a => a.Customer)
               .WithMany(a => a.customerAddresses)
               .HasForeignKey(a => a.CustomerId);
            modelBuilder.Entity<Experience>()
              .HasOne(a => a.Applicant)
              .WithMany(a => a.ExperienceDetail)
              .HasForeignKey(a => a.ApplicantId);           

        }



    }
}

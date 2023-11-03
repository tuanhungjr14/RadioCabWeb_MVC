using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadioCab.Models;

namespace RadioCab.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RolePayment>()
            .Property(r => r.Price)
            .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<IdentityUserLogin<string>>()
           .HasKey(l => new { l.LoginProvider, l.ProviderKey });


        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<RolePayment> RolePayments { get; set; }
       
        public DbSet<CabCompany> CabCompanies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<FeedbackType> FeedbackTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<AdImageUrl> AdImageUrls { get; set; }
       

    }
}

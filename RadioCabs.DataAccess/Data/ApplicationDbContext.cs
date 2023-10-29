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
            modelBuilder.Entity<Driver>().HasData(
                new Driver { DriverId = 1, DriverName = "A", DriverAddress = "HN",DriverPass="1",DriverDescripts="a",City="HN",Mobile="123456789",Email="a@gmail.com",Telephone="0284320523",Experience=100},
                new Driver { DriverId = 2, DriverName = "B", DriverAddress = "HN", DriverPass = "1", DriverDescripts = "a", City = "HN", Mobile = "123456788", Email = "b@gmail.com", Telephone = "0284320524", Experience = 100 },
                new Driver { DriverId = 3, DriverName = "C", DriverAddress = "HN", DriverPass = "1", DriverDescripts = "a", City = "HN", Mobile = "123456787", Email = "c@gmail.com", Telephone = "0284320525", Experience = 100 }
                );
            modelBuilder.Entity<IdentityUserLogin<string>>()
           .HasKey(l => new { l.LoginProvider, l.ProviderKey });


        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CabCompany> CabCompanies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<FeedbackType> FeedbackTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<CabOrder> CabOrders { get; set; }
        public DbSet<DriveOrder> DriveOrders { get; set; }
        public DbSet<AdOrder> AdOrders { get; set; }


    }
}

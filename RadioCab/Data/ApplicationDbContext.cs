using Microsoft.EntityFrameworkCore;
using RadioCab.Models;

namespace RadioCab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasData(
                new Driver { DriverId = 1, DriverName = "Action", DriverAddress = "HN",DriverPass="1",DriverDescripts="a",City="HN",Mobile="123456789",Email="a@gmail.com",Telephone="028432052",Experience=100},
                new Driver { DriverId = 2, DriverName = "SciFi", DriverAddress = "HN", DriverPass = "1", DriverDescripts = "a", City = "HN", Mobile = "123456789", Email = "a@gmail.com", Telephone = "028432052", Experience = 100 },
                new Driver { DriverId = 3, DriverName = "Histoty", DriverAddress = "HN", DriverPass = "1", DriverDescripts = "a", City = "HN", Mobile = "123456789", Email = "a@gmail.com", Telephone = "028432052", Experience = 100 }
                );

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<CabCompany> CabCompanies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<FeedbackType> feedbackTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<CabOrder> CabOrders { get; set; }
        public DbSet<DriveOrder> DriveOrders { get; set; }
        public DbSet<AdOrder> AdOrders { get; set; }


    }
}

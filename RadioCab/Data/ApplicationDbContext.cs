using Microsoft.EntityFrameworkCore;
using RadioCab.Models;

namespace RadioCab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

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

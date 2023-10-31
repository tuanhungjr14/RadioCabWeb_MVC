using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadioCab.Models
{
    public enum MembershipType
    {
        Basic,
        Premium,
        Free
    }

    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPasss { get; set; }

        public string AdminType { get; set; }
    }
    public class CabCompany
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string DesignNation { get; set; }
        public string CabAddress { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string MembershipType { get; set; }

    }
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPass { get; set; }
        public string DriverAddress { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public string DriverDescripts { get; set; }
    }
    public class Advertisment
    {
        [Key]
        public int AdId { get; set; }
        [ForeignKey("CabCompany")]
        public int CompanyId { get; set; }
        public string AdTilte { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string AdAddress { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AdDescript { get; set; }
        public string ImageUrl { get; set; }
    }
    public class FeedbackType
    {
        [Key]
        public int FeeId { get; set; }
        public string FeeName { get; set; }

    }


    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [MaxLength(15, ErrorMessage = "Mobile number cannot exceed 15 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Feedback type is required")]
        [ForeignKey("FeedbackType")]
        public string FeedbackType { get; set; }

        [Required(ErrorMessage = "Feedback description is required")]
        [MaxLength(500, ErrorMessage = "Feedback description cannot exceed 500 characters")]
        public string FeedDescript { get; set; }
    }

    public class Pricings

    {
        [Key]
        public int PriceId { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
    public class CabOrder
    {
        [Key]
        public int CorderId { get; set; }
        [ForeignKey("CabCompany")]
        public int CabId { get; set; }
        [ForeignKey("Pricings")]
        public int Price { get; set; }
        public string PaymentMethod { get; set; }


    }
    public class DriveOrder
    {
        [Key]
        public int DorderId { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        [ForeignKey("Pricings")]
        public int Price { get; set; }
        public string PaymentMethod { get; set; }


    }
    public class AdOrder
    {
        [Key]

        public int AorderId { get; set; }
        [ForeignKey("Advertisment")]
        public int AdId { get; set; }
        [ForeignKey("Pricings")]
        public int Price { get; set; }
        public string PaymentMethod { get; set; }


    }
}


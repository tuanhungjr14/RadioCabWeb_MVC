using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadioCab.Models
{

    public class CabCompany
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        public string ContactPerson { get; set; }
        public string DesignNation { get; set; }
        public string CabAddress { get; set; }

        [Phone(ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }

        [Phone(ErrorMessage = "Invalid Telephone number")]
        public string Telephone { get; set; }

        public string FaxNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string MembershipType { get; set; }
    }

    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required(ErrorMessage = "Driver Name is required")]
        public string DriverName { get; set; }

        public string DriverPass { get; set; }
        public string DriverAddress { get; set; }
        public string City { get; set; }

        [Phone(ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }

        [Phone(ErrorMessage = "Invalid Telephone number")]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50")]
        public int Experience { get; set; }

        public string DriverDescripts { get; set; }
    }

    public class Advertisment
    {
        [Key]
        public int AdId { get; set; }

        [ForeignKey("IdentityUser")]
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Advertisement Title is required")]
        public string AdTitle { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        public string Designation { get; set; }
        public string AdAddress { get; set; }

        [Phone(ErrorMessage = "Invalid Mobile number")]
        public string Mobile { get; set; }

        [Phone(ErrorMessage = "Invalid Telephone number")]
        public string Telephone { get; set; }

        [Phone(ErrorMessage = "Invalid Fax number")]
        public string Fax { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string AdDescript { get; set; }
        [ForeignKey("AdImageUrl")]
        public int ImageUrlId { get; set; }
    }

    public class FeedbackType
    {
        [Key]
        public int FeeId { get; set; }

        [Required(ErrorMessage = "Feedback Name is required")]
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

    
  
}


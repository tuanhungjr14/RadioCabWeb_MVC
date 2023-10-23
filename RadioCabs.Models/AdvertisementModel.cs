using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class AdvertisementModel
    {
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number should be 10 digits.")]
        public string Mobile { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telephone Number should be 10 digits.")]
        public string Telephone { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Fax Number should be 10 digits.")]
        public string FaxNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Payment Type is required.")]
        public string PaymentType { get; set; }

    }

}

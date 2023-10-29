using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number should be 10 digits.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }

}

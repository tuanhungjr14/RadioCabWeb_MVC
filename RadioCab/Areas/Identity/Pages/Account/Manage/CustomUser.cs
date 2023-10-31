using Microsoft.AspNetCore.Identity;
namespace RadioCab.Areas.Identity.Pages.Account.Manage
{


    public class CustomUser : IdentityUser
    {
        // Additional properties for Company or Driver
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        // Add other properties for the company

        public string DriverName { get; set; }
        public string DriverAddress { get; set; }
        public string City { get; set; }
        // Add other properties for the driver
    }
}

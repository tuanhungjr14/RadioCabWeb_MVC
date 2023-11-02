using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
     public class PaymentMethod : IdentityUser
    {
        public string MembershipType { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }

        public async Task<decimal> CalculateAmount(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByIdAsync(this.Id);

            var roles = await userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (role == "Driver")
            {
                if (PaymentType == "Monthly")
                {
                    return MembershipType == "Premium" ? 10 : 15;
                }
                else if (PaymentType == "Quarterly")
                {
                    return MembershipType == "Premium" ? 25 : 40;
                }
            }
            else if (role == "Advertisment")
            {
                if (PaymentType == "Monthly")
                {
                    return MembershipType == "Premium" ? 15 : 15;
                }
                else if (PaymentType == "Quarterly")
                {
                    return MembershipType == "Premium" ? 40 : 40;
                }
            }

            return 0; 
        }
    }
}

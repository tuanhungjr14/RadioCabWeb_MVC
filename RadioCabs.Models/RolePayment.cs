using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class RolePayment
    {
        [Key]
        public int RolePaymentId { get; set; }
        [ForeignKey("AspNetUserRoles")]
        public string RoleId { get; set; }
       [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public decimal Price { get; set; }
    }
}

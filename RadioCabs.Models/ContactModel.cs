using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message là bắt buộc")]
        [StringLength(500, ErrorMessage = "Độ dài tối đa là 500 ký tự")]
        public string Message { get; set; }
    }
}

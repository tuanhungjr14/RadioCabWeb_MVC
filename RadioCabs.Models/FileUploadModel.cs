using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class FileUploadModel
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile File { get; set; }
    }

}

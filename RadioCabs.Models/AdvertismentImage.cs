using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class AdvertismentImage
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int AId { get; set; }
        [ForeignKey("AId")]
        public Advertisment Advertisments { get; set; }
    }
}



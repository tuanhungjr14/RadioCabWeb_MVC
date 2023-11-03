using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.Models
{
    public class AdImageUrl
    {
        [Key]
        public int AdImageUrlId { get; set; }
        
        public string? Image { get; set; }
    }
}

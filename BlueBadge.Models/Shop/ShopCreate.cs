using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class ShopCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter in a shop name.")]
        public string ShopName { get; set; }
        public string ShopUrl { get; set; }

    }
}

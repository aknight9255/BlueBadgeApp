using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        [Required]
        public string ShopName { get; set; }
        public string ShopURL { get; set; }
    }
}

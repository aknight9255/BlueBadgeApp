using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class ShopDetails
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        [Display(Name ="Shop Website")]
        public string ShopUrl { get; set; }
    }
}

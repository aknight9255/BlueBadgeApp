using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class ArtistCreate
    {
        [Required]
        public string ArtistName { get; set; }
        [Required]
        [Display(Name = "Contact Info")]
        public string ArtistContact { get; set; }

        [Required]
        [ForeignKey("Shop")]
        public int ShopID { get; set; }
        public virtual Shop Shop { get; set; }
    }
}

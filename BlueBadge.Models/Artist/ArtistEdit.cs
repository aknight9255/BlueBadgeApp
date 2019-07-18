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
    public class ArtistEdit
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        [Display(Name = "Contact Info")]
        public string ArtistContact { get; set; }

        [ForeignKey("Shop")]
        public int ShopID { get; set; }
        public virtual Shop Shop { get; set; }
    }
}

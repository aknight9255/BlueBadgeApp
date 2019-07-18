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
    public class ArtistListItem
    {
        public int ArtistID { get; set; }
        [Display(Name ="Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Artist Website")]
        public string ArtistURL { get; set; }

        [ForeignKey("Shop")]
        public int ShopID { get; set; }
        public virtual Shop Shop { get; set; }
    }
}

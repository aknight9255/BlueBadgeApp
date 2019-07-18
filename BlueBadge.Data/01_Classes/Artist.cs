using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Required]
        public string ArtistContact { get; set; }
        [ForeignKey("Shop")]
        public int ShopID { get; set; }
        public virtual Shop Shop { get; set; }

        public string ArtistURL { get; set; }

    }

}

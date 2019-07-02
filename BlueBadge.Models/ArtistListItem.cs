using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}

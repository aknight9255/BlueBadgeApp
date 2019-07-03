using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("Artist")]
        [Display(Name ="Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        [Required]
        [Display(Name ="Tattoo Details")]
        public string TattooDetails { get; set; }


    }
}

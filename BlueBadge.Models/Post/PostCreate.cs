using BlueBadge.Data;
using BlueBadge.Models.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlueBadge.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter a title.")]
        [MaxLength(120, ErrorMessage = "Your title is to long.")]
        public string Title { get; set; }
        [ForeignKey("Artist")]
        [Display(Name = "Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        [Display(Name = "Tattoo Details")]
        [MaxLength(8000)]
        public string TattooDetails { get; set; }
        [NotMapped]
        public HttpPostedFileBase Upload { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public virtual ICollection<Photo> Files { get; set; }
    }
}

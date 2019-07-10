using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlueBadge.Models.Post
{
    public class PostDetail
    {
        public int PostID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        [Required]
        [Display(Name = "Tattoo Details")]
        public string TattooDetails { get; set; }
        [NotMapped]
        public HttpPostedFileBase Upload { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public virtual ICollection<Photo> Files { get; set; }
    }
}

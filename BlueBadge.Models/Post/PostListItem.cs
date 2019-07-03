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
    public class PostListItem
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        [ForeignKey("Artist")]
        [Display(Name = "Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
    }
}

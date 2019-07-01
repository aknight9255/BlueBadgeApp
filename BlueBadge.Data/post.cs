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
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }


    }
}

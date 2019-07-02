using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeServices
{
    public class ArtistService
    {
        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    ArtistName = model.ArtistName,
                    ArtistURL = model.ArtistURL,
                    ShopID = model.ShopID,
                    PhoneNumber = model.PhoneNumber
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Artists.Select(
                       e =>
                            new ArtistListItem
                            {
                                ArtistID = e.ArtistID,
                                ArtistName = e.ArtistName
                            }); 
                return query.ToArray();
            }
        }
    }
}

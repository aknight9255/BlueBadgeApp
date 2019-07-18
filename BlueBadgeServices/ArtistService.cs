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
                    ShopID = model.ShopID,
                    Shop = model.Shop,
                    ArtistContact = model.ArtistContact
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
                                ArtistName = e.ArtistName,
                                ShopID = e.ShopID,
                                ArtistContact = e.ArtistContact
                            }); 
                return query.ToArray();
            }
        }
        public ArtistDetails GetArtistByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistID == id);
                return
                    new ArtistDetails
                    {
                        ArtistID = entity.ArtistID,
                        ArtistContact= entity.ArtistContact,
                        ShopID = entity.ShopID,
                        Shop = entity.Shop,
                    };
            }
        }
        public bool UpdateArtist (ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Artists.Single
                    (e => e.ArtistID == model.ArtistID);
                entity.ArtistName = model.ArtistName;
                entity.ArtistContact = model.ArtistContact;
                entity.ShopID = model.ShopID;
                entity.Shop = model.Shop;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistID == artistID);
                    ctx.Artists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

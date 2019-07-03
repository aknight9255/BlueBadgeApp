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
                    Shop = model.Shop,
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
                        ArtistName = entity.ArtistName,
                        PhoneNumber = entity.PhoneNumber,
                        ShopID = entity.ShopID,
                        Shop = entity.Shop,
                        ArtistURL = entity.ArtistURL
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
                entity.PhoneNumber = model.PhoneNumber;
                entity.ShopID = model.ShopID;
                entity.Shop = model.Shop;
                entity.ArtistURL = model.ArtistURL;
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

using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeServices
{
    public class ShopService
    {
        public bool CreateShop(ShopCreate model)
        {
            var entity = new Shop()
            { 
                ShopName = model.ShopName,
                ShopURL = model.ShopUrl
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShopListItem> GetShops()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Shops.Select(
                       e =>
                            new ShopListItem
                            {
                                ShopID = e.ShopID,
                                ShopName = e.ShopName
                            });
                return query.ToArray();
            }
        }

        public ShopDetails GetShopByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shops
                    .Single(e => e.ShopID==id);
                return
                    new ShopDetails
                    {
                        ShopID = entity.ShopID,
                        ShopName = entity.ShopName,
                        ShopUrl = entity.ShopURL
                    };
            }
        }

        
    }
}

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
        private readonly Guid _userID;
        public ShopService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateShop(ShopCreate model)
        {
            var entity = new Shop()
            {
                OwnerID = _userID,
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
                   ctx
                    .Shops
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                       e =>
                            new ShopListItem
                            {
                                ShopID = e.ShopID,
                                ShopName = e.ShopName
                            }
                            );
                return query.ToArray();
            }
        }
    }
}

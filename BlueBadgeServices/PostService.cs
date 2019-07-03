using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeServices
{
    public class PostService
    {
        private readonly Guid _userID;
        public PostService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    OwnerID = _userID,
                    Title = model.Title,
                    ArtistID = model.ArtistID,
                    Artist = model.Artist,
                    TattooDetails = model.TattooDetails
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.OwnerID == _userID)
                    .Select(e =>
                                new PostListItem
                                {
                                    PostID = e.PostID,
                                    Title = e.Title,
                                    ArtistID = e.ArtistID,
                                    Artist = e.Artist
                                });
                return query.ToArray();
            }
        }
        public PostDetail GetPostbyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == id && e.OwnerID == _userID);
                return
                    new PostDetail
                    {
                        PostID = entity.PostID,
                        Title = entity.Title,
                        ArtistID = entity.ArtistID,
                        Artist = entity.Artist,
                        TattooDetails = entity.TattooDetails
                    };
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts.Single
                    (e => e.PostID == model.PostID && e.OwnerID == _userID);
                entity.Title = model.Title;
                entity.ArtistID = model.ArtistID;
                entity.Artist = model.Artist;
                entity.TattooDetails = model.TattooDetails;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int postID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single
                    (e => e.PostID == postID && e.OwnerID == _userID);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

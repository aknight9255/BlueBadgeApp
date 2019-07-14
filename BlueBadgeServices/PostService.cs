using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            if (model.Upload != null && model.Upload.ContentLength > 0)
            {
                var avatar = new Photo
                {
                    PhotoName = System.IO.Path.GetFileName(model.Upload.FileName),
                    FileType = FileType.Picture,
                    ContentType = model.Upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(model.Upload.InputStream))
                {
                    avatar.Content = reader.ReadBytes(model.Upload.ContentLength);
                }
                model.Files = new List<Photo> { avatar };
            }
            var entity =
                new Post()
                {
                    OwnerID = _userID,
                    Title = model.Title,
                    ArtistID = model.ArtistID,
                    Artist = model.Artist,
                    TattooDetails = model.TattooDetails,
                    Files = model.Files,
                    Upload = model.Upload,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                int actual = ctx.SaveChanges();
                return actual >= 1;
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
                    .Include(e => e.Files)
                    .Single(e => e.PostID == id && e.OwnerID == _userID);
                return
                    new PostDetail
                    {
                        PostID = entity.PostID,
                        Title = entity.Title,
                        ArtistID = entity.ArtistID,
                        Artist = entity.Artist,
                        TattooDetails = entity.TattooDetails,
                        Files = entity.Files,
                        PhotoId = entity.Files.ToList()[0].PhotoId
                    };
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    if (model.Files.Any(f => f.FileType == FileType.Picture))
                    {
                        /*ctx.Photos.Remove(model.Files.First(f => f.FileType == BlueBadge.Data.FileType.Picture));*/
                        var previousFile = ctx.Photos.Single(pF => pF.PhotoId == model.PhotoId);
                        ctx.Photos.Remove(previousFile);
                    }
                    var avatar = new Photo
                    {
                        PhotoName = System.IO.Path.GetFileName(model.Upload.FileName),
                        FileType = FileType.Picture,
                        ContentType = model.Upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(model.Upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(model.Upload.ContentLength);
                    }
                    model.Files = new List<Photo> { avatar };
                }
                var entity =
                ctx.Posts.Single
                (e => e.PostID == model.PostID && e.OwnerID == _userID);
                entity.Title = model.Title;
                entity.ArtistID = model.ArtistID;
                entity.TattooDetails = model.TattooDetails;
                entity.Files = model.Files;
                entity.Upload = model.Upload;
                return ctx.SaveChanges() >= 1;
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

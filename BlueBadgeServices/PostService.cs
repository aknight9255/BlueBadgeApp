﻿using BlueBadge.Data;
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
                                    Title = e.Title
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
                        TattooDetails = entity.TattooDetails
                    };
            }
        }

    }
}

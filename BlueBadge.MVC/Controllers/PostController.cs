using BlueBadge.Models;
using BlueBadgeServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.MVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var service = CreatePostService();
            var model = service.GetPosts();
            return View(model);
        }



        //GET CREATE
        public ActionResult Create()
        {
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName");
            return View();
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName");
            if (!ModelState.IsValid) return View(model);
            var service = CreatePostService();
            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your post was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Post could not be created.");
            return View(model);
        }



        private PostService CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userID);
            return service;
        }
    }
}
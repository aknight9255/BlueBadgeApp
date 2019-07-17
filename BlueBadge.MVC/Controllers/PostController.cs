using BlueBadge.Models;
using BlueBadge.Models.Post;
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
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName");
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
        //GET DETAILS
        public ActionResult Details(int id)
        {
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName");
            var svc = CreatePostService();
            var model = svc.GetPostbyID(id);
            return View(model);
        }
        //GET EDIT 
        public ActionResult Edit (int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostbyID(id);
            var model =
                new PostEdit
                {
                    PostID = detail.PostID,
                    PhotoId = detail.PhotoId,
                    Title = detail.Title,
                    ArtistID = detail.ArtistID,
                    TattooDetails = detail.TattooDetails,
                    Files = detail.Files,
                };
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName", model.ArtistID);
            return View(model);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName",model.ArtistID);
            var service = CreatePostService();
            var detail = service.GetPostbyID(id);
            var modelPrevious =
                new PostEdit
                {
                    Files = detail.Files,
                };

            model.Files = modelPrevious.Files;
            model.PhotoId = detail.PhotoId;

            if (!ModelState.IsValid) return View(model);
            if (model.PostID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (service.UpdatePost(model))
            {
                TempData["SaveResult"] = "The post was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The post could not be saved. Either no changes were made or fields have been filled out incorrectly.");

            return View(model);
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            var db = new ArtistService();
            ViewBag.ArtistID = new SelectList(db.GetArtists().ToList(), "ArtistID", "ArtistName");
            var svc = CreatePostService();
            var model = svc.GetPostbyID(id);
            return View(model);
        }
        //POST DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();
            service.DeletePost(id);
            TempData["SaveResult"] = "The post has been deleted";
            return RedirectToAction("Index");
        }

        //GET MAIN 
        public ActionResult MAIN()
        {
            return View();
        }

        private PostService CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userID);
            return service;
        }
    }
}
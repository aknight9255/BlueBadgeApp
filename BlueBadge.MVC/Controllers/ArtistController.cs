using BlueBadge.Models;
using BlueBadgeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.MVC.Controllers
{
    
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var service = new ArtistService();
            var model = service.GetArtists();
            return View(model);
        }
        //GET CREATE
        public ActionResult Create()
        {
            var db = new ShopService();
            ViewBag.ShopID = new SelectList(db.GetShops().ToList(), "ShopID", "ShopName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (ArtistCreate model)
        {
            var db = new ShopService();
            ViewBag.ShopID = new SelectList(db.GetShops().ToList(), "ShopID","ShopName");
            if (!ModelState.IsValid) return View(model);
            var service = new ArtistService();
            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Artist could not be added.");
            return View(model);

        }
    }
}
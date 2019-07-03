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
        //POST CREATE
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

        //GET DETAILS
        public ActionResult Details(int id)
        {
            var svc = new ArtistService();
            var model = svc.GetArtistByID(id);
            return View(model);
        }
        // GET EDIT 
        public ActionResult Edit(int id)
        {
            var service = new ArtistService();
            var detail = service.GetArtistByID(id);
            var model =
                new ArtistEdit
                {
                    ArtistID = detail.ArtistID,
                    ArtistName = detail.ArtistName,
                    PhoneNumber = detail.PhoneNumber,
                    ArtistURL = detail.ArtistURL,
                    ShopID = detail.ShopID
                };
            return View(model);
        }
        //POST EDIT 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ArtistID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new ArtistService();
            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "The Artist was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "This Artist could not be updated.");
            return View(model);
        }

    }
}
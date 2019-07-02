using BlueBadge.Data;
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
    public class ShopController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Shop
        public ActionResult Index()
        {
            var service = new ShopService();
            var model = service.GetShops();
            return View(model);
        }
        //GET CREATE 
        public ActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new ShopService();
            if (service.CreateShop(model))
            {
                TempData["SaveResult"] = "Shop added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Shop could not be added.");
            return View(model);
        }

        //GET DETAILS
        public ActionResult Details(int id)
        {
            var svc = new ShopService();
            var model = svc.GetShopByID(id);
            return View(model);
        }

        //Get Edit 
        public ActionResult Edit(int id)
        {
            var service = new ShopService();
            var detail = service.GetShopByID(id);
            var model =
                new ShopEdit
                {
                    ShopID = detail.ShopID,
                    ShopName = detail.ShopName,
                    ShopURL = detail.ShopUrl
                };
            return View(model);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShopEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShopID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new ShopService();
            if (service.UpdateShop(model))
            {
                TempData["SavesResult"] = "The shop has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "This shop could not be updated.");
            return View(model);
        }
        //GET Delete
        public ActionResult Delete(int id)
        {
            var svc = new ShopService();
            var model = svc.GetShopByID(id);
            return View(model);
        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new ShopService();
            service.DeleteShop(id);
            TempData["SaveResult"] = "The shop has been deleted.";
            return RedirectToAction("Index");
        }
    }
}
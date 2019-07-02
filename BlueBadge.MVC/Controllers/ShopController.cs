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



    }
}
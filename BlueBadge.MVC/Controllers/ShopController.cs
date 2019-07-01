using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.MVC.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var model = new ShopListItem[0];
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
        public ActionResult Create (ShopCreate model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
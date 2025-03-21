using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class ChefController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Chef
        public ActionResult Index()
        {
            var values = db.Chefs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = db.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var value = db.Chefs.Find(chef.ChefId);
            value.Name = chef.Name;
            value.Title = chef.Title;
            value.ImageUrl = chef.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateChef(Chef chef)
        {
            db.Chefs.Add(chef);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChef(int id)
        {
            var value = db.Chefs.Find(id);
            db.Chefs.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
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
    public class CategoryController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Categories.ToList();
            return View(value);
        }
        public ActionResult CategoryList()
        {
            var value = db.Categories.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var value = db.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category model)
        {
            var value = db.Categories.Find(model.CategoryId);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            var value = db.Categories.Find(id);
            db.Categories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
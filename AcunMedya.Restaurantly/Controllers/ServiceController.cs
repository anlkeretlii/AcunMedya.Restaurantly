using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ServiceController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var values = db.Services.ToList();
            return View(values);
        }
        public ActionResult UpdateService(int id)
        {
            var values = db.Services.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(Service p)
        {
            var values = db.Services.Find(p.ServiceId);
            values.Title = p.Title;
            values.Description = p.Description;
            
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service s)
        {
            db.Services.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.Services.Find(id);
            db.Services.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
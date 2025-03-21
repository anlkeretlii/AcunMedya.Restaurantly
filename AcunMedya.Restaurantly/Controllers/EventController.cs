using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
   
// GET: Event
    public class EventController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var values = db.Events.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            var value = db.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEvent(Event Event)
        {
            var value = db.Events.Find(Event.EventId);
            value.Title = Event.Title;
            value.Description = Event.Description;
            value.ImageUrl = Event.ImageUrl;
            value.Price = Event.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEvent(Event j)
        {
            db.Events.Add(j);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEvent(int id)
        {
            var value = db.Events.Find(id);
            db.Events.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
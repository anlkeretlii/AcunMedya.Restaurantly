using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ContactController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var values = db.Contacts.ToList();
            return View(values);
        }
        public ActionResult Message(int id)
        {
            var values = db.Contacts.Find(id);
            values.IsRead = true;
            db.SaveChanges();
            return View(values);
        }
        public ActionResult DeleteContact(int id)
        {
            var values = db.Contacts.Find(id);
            db.Contacts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
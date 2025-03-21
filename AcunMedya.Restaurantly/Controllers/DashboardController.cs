using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Productcount = Db.Products.Count();
            ViewBag.CategoryCount = Db.Categories.Count();
            ViewBag.Chefcount = Db.Chefs.Count();
            ViewBag.SpecialCount = Db.Specials.Count();
            return View();
        }

        public PartialViewResult RezervasionPartial()
        {
            var value = Db.Reservations.ToList();
            return PartialView(value);

        }

        public PartialViewResult ReservationPartial()
        {
            var reservations = Db.Reservations.OrderByDescending(x => x.ReservationDate).Take(5).ToList();
            return PartialView(reservations);
        }

        public PartialViewResult MessagePartial()
        {
            var messages = Db.Contacts.OrderByDescending(x => x.SendDate).Take(5).ToList();
            return PartialView(messages);
        }

    }
}
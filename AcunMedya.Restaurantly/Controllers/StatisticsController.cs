using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly RestaurantlyContext db = new RestaurantlyContext();

        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ChefCount = db.Chefs.Count();
            ViewBag.ReservationCount = db.Reservations.Count();
            ViewBag.SpecialCount = db.Specials.Count();
            ViewBag.TestimonialCount = db.Testimonials.Count();
            ViewBag.FeatureCount = db.Features.Count();
            ViewBag.AddressCount = db.Addresses.Count();
            ViewBag.AdminCount = db.Admins.Count();
            ViewBag.NotificationCount = db.Notifications.Count();
            ViewBag.MessageCount = db.Contacts.Count();
            ViewBag.GalleryCount = db.Galleries.Count();
            ViewBag.EventCount = db.Events.Count();
            ViewBag.ServiceCount = db.Services.Count();
            


            return View();
        }
    }
}
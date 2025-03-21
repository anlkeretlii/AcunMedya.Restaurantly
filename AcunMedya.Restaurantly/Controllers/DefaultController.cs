using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class DefaultController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = db.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.OpenHours = db.Addresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.SubTitle = db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title = db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = db.Features.Select(x => x.VideoUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var values = db.Services.ToList();
            return PartialView(values);
        }


        public PartialViewResult PartialMenu()
        {
            var value = db.Products.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            db.Contacts.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");

        }

        public PartialViewResult PartialSpecial()
        {
            var values = db.Specials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialBookaTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddBookaTable(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            model.Status = ReservationStatus.Pending; // Replace 'Beklemede' with 'Pending' or the correct enum value
            db.Reservations.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Rezervasyon Başarılı";
            return View("Index");

        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialChef()
        {
            var values = db.Chefs.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAddress()
        {

            ViewBag.Location = db.Addresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.Email = db.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.Call = db.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.OpenHours = db.Addresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialEvent()
        {
            var values = db.Events.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialGallery()
        {
            var values = db.Galleries.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            ViewBag.Location = db.Addresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.Email = db.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.Phone = db.Addresses.Select(x => x.Phone).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}
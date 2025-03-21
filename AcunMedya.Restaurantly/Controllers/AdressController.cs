using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();

        public ActionResult AddressIndex()
        {
            var values = db.Addresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.Addresses.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(Address updatedAddress)
        {
            var values = db.Addresses.Find(updatedAddress.AddressId);
            values.Location = updatedAddress.Location;
            values.OpenHours = updatedAddress.OpenHours;
            values.Email = updatedAddress.Email;
            values.Phone = updatedAddress.Phone;
            db.SaveChanges();
            return RedirectToAction("AddressIndex");
        }
        [HttpGet]
        public ActionResult CreateAddress()
        {
            return View();
        }

        // Change the type of the parameter in CreateAddress method to match the DbSet type
        [HttpPost]
        public ActionResult CreateAddress(Address newAddress) // Change Address to Adress
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(newAddress);
                db.SaveChanges();
                return RedirectToAction("AddressIndex");
            }
            return View(newAddress);
        }

        [HttpPost]
        public ActionResult DeleteAddress(int id)
        {
            var address = db.Addresses.Find(id);
            if (address != null)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
            }
            return RedirectToAction("AddressIndex");
        }
    }
}
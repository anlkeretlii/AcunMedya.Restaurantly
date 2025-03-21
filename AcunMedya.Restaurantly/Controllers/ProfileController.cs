using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        RestaurantlyContext db = new RestaurantlyContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["ID"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            if (value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Şifre hatalı");
                return View(p);
            }
            if (p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Images\\";
                var fileName = Path.Combine(saveLocation, p.ImageFile.FileName);
                p.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/Images/" + p.ImageFile.FileName;
            }
            else
            {
                value.ImageUrl = p.ImageUrl;
            }
            value.UserName = p.UserName;
            value.Password = p.Password;
            value.Name = p.Name;
            value.Description = p.Description;
            value.Email = p.Email;
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult UpdateProfile(Admin admin)
        {
            if (admin.ImageFile != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(admin.ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                admin.ImageFile.SaveAs(path);
                admin.ImageUrl = "/Images/" + fileName;
            }

            var existingAdmin = db.Admins.Find(admin.AdminId);
            if (existingAdmin == null)
            {
                return HttpNotFound();
            }

            existingAdmin.Name = admin.Name;
            existingAdmin.Surname = admin.Surname;
            existingAdmin.Title = admin.Title;
            existingAdmin.Description = admin.Description;
            existingAdmin.Email = admin.Email;
            existingAdmin.Phone = admin.Phone;
            existingAdmin.UserName = admin.UserName;
            
            if (!string.IsNullOrEmpty(admin.Password))
            {
                existingAdmin.Password = admin.Password;
            }
            
            if (!string.IsNullOrEmpty(admin.ImageUrl))
            {
                existingAdmin.ImageUrl = admin.ImageUrl;
            }

            db.SaveChanges();

            // Session bilgilerini güncelle
            Session["Username"] = existingAdmin.UserName;
            Session["Name"] = existingAdmin.Name;
            Session["Image"] = existingAdmin.ImageUrl;
            Session["Email"] = existingAdmin.Email;

            return RedirectToAction("Index");
        }
    }
}
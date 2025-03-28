﻿using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedya.Restaurantly.Controllers
{

    public class AdminLayoutController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            var mesajlar = Db.Contacts.ToList();
            ViewBag.notificationIsReadByFalseCount = Db.Notifications.Where(x => x.isRead == false).Count();
            var values = Db.Notifications.Where(x => x.isRead == false).ToList();
            ViewBag.mesajlar = mesajlar;
            ViewBag.okunmamisMesajSayisi = Db.Contacts.Where(x => x.IsRead == false).Count();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = Db.Notifications.Find(id);
            value.isRead = true;
            Db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }

        public PartialViewResult PartialContact()
        {
            ViewBag.messageIsReadByFalseCount = Db.Contacts.Where(x => x.IsRead == false).Count();
            var values = Db.Contacts.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }

        public ActionResult ContactStatusChangeToTrue(int id)
        {
            var value = Db.Contacts.Find(id);
            value.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }




    }
}
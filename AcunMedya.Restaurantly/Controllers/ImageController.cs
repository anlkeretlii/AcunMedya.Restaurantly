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
    public class ImageController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Gallery


        public ActionResult GalleryList()
        {

            var value = Db.Galleries.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult GalleryCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GalleryCreate(Images model)
        {
            Db.Galleries.Add(model);
            Db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        [HttpGet]
        public ActionResult GalleryEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GalleryList");
            }

            var gallery = Db.Galleries.Find(id);
            if (gallery == null)
            {
                return RedirectToAction("GalleryList");
            }

            return View(gallery);
        }
        [HttpPost]
        public ActionResult GalleryEdit(Images model)
        {
            var value = Db.Galleries.Find(model.ImagesId);
            value.ImageUrl = model.ImageUrl;
            value.Title = model.Title;
            Db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        public ActionResult GalleryDelete(int id)
        {
            var value = Db.Galleries.Find(id);
            Db.Galleries.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("GalleryList");
        }

    }
}
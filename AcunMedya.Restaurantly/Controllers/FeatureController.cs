using System.Linq;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        private readonly RestaurantlyContext _context = new RestaurantlyContext();

        public ActionResult Index()
        {
            var features = _context.Features.ToList();
            return View(features);
        }

        public ActionResult FeatureList()
        {
            var features = _context.Features.ToList();
            return View(features);
        }

        [HttpGet]
        public ActionResult FeatureCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeatureCreate(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Features.Add(feature);
                _context.SaveChanges();
                return RedirectToAction("FeatureList");
            }
            return View(feature);
        }

        [HttpGet]
        public ActionResult FeatureEdit(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        [HttpPost]
        public ActionResult FeatureEdit(Feature feature)
        {
            if (ModelState.IsValid)
            {
                var existingFeature = _context.Features.Find(feature.FeatureId);
                if (existingFeature != null)
                {
                    existingFeature.SubTitle = feature.SubTitle;
                    existingFeature.Title = feature.Title;
                    existingFeature.ImageUrl = feature.ImageUrl;
                    _context.SaveChanges();
                    return RedirectToAction("FeatureList");
                }
                return HttpNotFound();
            }
            return View(feature);
        }

        public ActionResult FeatureDelete(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                _context.SaveChanges();
                return RedirectToAction("FeatureList");
            }
            return HttpNotFound();
        }
    }
}

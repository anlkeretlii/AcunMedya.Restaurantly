using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly RestaurantlyContext _context = new RestaurantlyContext();

        public ActionResult Index()
        {
            var notifications = _context.Notifications.ToList();
            return View(notifications);
        }

        public ActionResult NotificationList()
        {
            var notifications = _context.Notifications.ToList();
            return View(notifications);
        }

        public ActionResult MarkAsRead(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.isRead = true;
                _context.SaveChanges();
                return RedirectToAction("NotificationList");
            }
            return HttpNotFound();
        }

        public ActionResult MarkAsUnread(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.isRead = false;
                _context.SaveChanges();
                return RedirectToAction("NotificationList");
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
                return RedirectToAction("NotificationList");
            }
            return HttpNotFound();
        }
    }
}


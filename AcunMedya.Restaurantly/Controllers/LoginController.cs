using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedya.Restaurantly.Controllers
{
        // GET: Login
        [AllowAnonymous]
        public class LoginController : Controller
        {
            RestaurantlyContext db = new RestaurantlyContext();
            [HttpGet]
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Index(Admin p)
            {
                var values = db.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
                if (values != null)
                {
                    FormsAuthentication.SetAuthCookie(values.UserName, false);
                    Session["Username"] = values.UserName.ToString();
                    Session["ID"] = values.AdminId;
                    Session["Name"] = values.Name.ToString();
                   
                    Session["Image"] = values.ImageUrl.ToString();
                    Session["Email"] = values.Email.ToString();
                    Session["Password"] = values.Password.ToString();
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return View();
                }
            }
            public ActionResult Logout()
            {
                Session.Clear();
                Session.Abandon();

                return RedirectToAction("Index", "Login");
            }
        }
}
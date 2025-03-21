using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedya.Restaurantly.Entities;
using AcunMedya.Restaurantly.Context;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly RestaurantlyContext _context = new RestaurantlyContext();

        public ActionResult Index()
        {
            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

        public ActionResult ReservationList()
        {
            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

        [HttpGet]
        public ActionResult ReservationCreate()
        {
            ViewBag.StatusList = GetStatusList();
            return View();
        }

        [HttpPost]
        public ActionResult ReservationCreate(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return RedirectToAction("ReservationList");
            }
            ViewBag.StatusList = GetStatusList();
            return View(reservation);
        }

        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusList = GetStatusList();
            return View(reservation);
        }

        [HttpPost]
        public ActionResult ReservationEdit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var existingReservation = _context.Reservations.Find(reservation.ReservationId);
                if (existingReservation != null)
                {
                    existingReservation.Name = reservation.Name;
                    existingReservation.Email = reservation.Email;
                    existingReservation.Phone = reservation.Phone;
                    existingReservation.Description = reservation.Description;
                    existingReservation.ReservationDate = reservation.ReservationDate;
                    existingReservation.TimeSlot = reservation.TimeSlot;
                    existingReservation.GuestCount = reservation.GuestCount;
                    existingReservation.Status = reservation.Status;
                    _context.SaveChanges();
                    return RedirectToAction("ReservationList");
                }
                return HttpNotFound();
            }
            ViewBag.StatusList = GetStatusList();
            return View(reservation);
        }

        public ActionResult ReservationDelete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
                return RedirectToAction("ReservationList");
            }
            return HttpNotFound();
        }

        private List<SelectListItem> GetStatusList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Beklemede", Value = "Beklemede" },
        new SelectListItem { Text = "Onaylandı", Value = "Onaylandı" },
        new SelectListItem { Text = "İptal Edildi", Value = "İptal Edildi" }
            };
        }
    }
}

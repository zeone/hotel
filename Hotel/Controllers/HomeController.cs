using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hotel.Enums;
using Hotel.Helpers;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        EmailHelper emailHelper = new EmailHelper();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            ViewBag.Count = db.Gallery.Count();
            return View(db.Gallery.OrderBy(r=>r.ImgId).Take(10).ToList());
        }

        [HttpGet]
        public JsonResult NextPics(int nextCount)
        {
            return Json(db.Gallery.OrderBy(r => r.ImgId).Skip(nextCount - 10).Take(10), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Healing()
        {

            return View();
        }


        public ActionResult Prices()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Reservation(DateTime? indexStartDate, DateTime? indexEndDate, int? GuestCount)
        {
            var newReserv = new ReservationView()
            {
                StartDate = indexStartDate == null || indexStartDate.Value == DateTime.MinValue ? DateTime.Now : indexStartDate.Value,
                EndDate = indexEndDate == null || indexEndDate.Value == DateTime.MinValue ? DateTime.Now : indexEndDate.Value,
                GuestCount = GuestCount == null || GuestCount.Value == 0 ? 1 : GuestCount.Value
            };
            newReserv.Types = db.ApTypes.ToList();
            return View(newReserv);
        }

        [HttpPost]
        public async Task<ActionResult> Reservation(ReservationView reserv)
        {
            // var appId = db.Apartments.FirstOrDefault(t => t.ApTypeId == reserv.TypeId).ApartmentId;
            var appartment = db.Apartments.Include(r => r.Type).FirstOrDefault(r => r.ApTypeId == reserv.TypeId);
            //   var price = db.ApTypes.FirstOrDefault(w => w.TypeId == reserv.TypeId).Price;
            var reservation = new Reservation()
            {
                StartDate = reserv.StartDate,
                GuestCount = reserv.GuestCount,
                Name = reserv.Name,
                EndDate = reserv.EndDate,
                ApartmentId = appartment.ApartmentId,
                ChildrenCount = reserv.ChildrenCount,
                Note = reserv.Note,
                PhoneNumber = reserv.PhoneNumber,
                Status = ReservationStatus.ReservedByUser,
                ReservationPriсe = PriceHelper.GetPrice(appartment.Type, reserv.GuestCount),
                Email = reserv.Email
            };
            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();

            reservation.Apartment =
                db.Apartments.Include(r => r.Type).FirstOrDefault(r => r.ApTypeId == reserv.TypeId);
            await Task.Run(() => emailHelper.SendEmail(reservation, Server));


            return RedirectToAction("Index");
        }

        public ActionResult Rooms()
        {

            return View(db.ApTypes.ToList());
        }

        [HttpGet]

        public JsonResult GetAppPrice(int apTypeId, int gusetCount)
        {
            var type = db.ApTypes.Find(apTypeId);
            return Json(PriceHelper.GetPrice(type, gusetCount), JsonRequestBehavior.AllowGet);
        }


    }
}
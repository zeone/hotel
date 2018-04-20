using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
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

        public ActionResult Gallery()
        {

            return View(db.Gallery.ToList());
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
            NameValueCollection nvc = Request.Form;

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
        public ActionResult Reservation(ReservationView reserv)
        {

            return RedirectToAction("Index");
        }

        public ActionResult Rooms()
        {

            return View();
        }

        [HttpGet]

        public JsonResult GetAppPrice(int apTypeId, int gusetCount)
        {
            var price = db.ApTypes.Find(apTypeId)?.Price;
            return Json(price, JsonRequestBehavior.AllowGet);
        }
    }
}
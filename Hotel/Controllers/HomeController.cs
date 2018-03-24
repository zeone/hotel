using System;
using System.Collections.Generic;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ApList()
        {
            var apps = db.Apartments.ToList();
            return View(apps);
        }
    }
}
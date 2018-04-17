﻿using System;
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
        public ActionResult Reservation(Reservation reserv)
        {
            NameValueCollection nvc = Request.Form;
            var model = reserv;
            return View();
        }


        public ActionResult Rooms()
        {

            return View();
        }

    }
}
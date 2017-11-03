using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassworkPractic.Models;

namespace ClassworkPractic.Controllers
{
    public class HallsController : Controller
    {
        private Cinema db = new Cinema();
        // GET: Halls
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlueHall()
        {
            ViewBag.sessions = db.Sessions.Where(s => s.HallID == 1);
            ViewBag.halls = db.Halls;
            return View();
        }
    }
}
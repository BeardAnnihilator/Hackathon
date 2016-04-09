using CompeStrava.Strava;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompeStrava.Global;

namespace CompeStrava.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = Global.Global.strava.GetClubs();
            return View(model);
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
    }
}
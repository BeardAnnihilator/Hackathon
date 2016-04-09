using CompeStrava.Strava;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompeStrava.Global;
using Strava.Athletes;
using Strava.Clubs;
using CompeStrava.ViewModel;
using CompeStrava.Business;

namespace CompeStrava.Controllers
{
    public class HomeController : Controller
    {
        CompestravaBusiness business = new CompestravaBusiness();

        public ActionResult Index()
        {
            var model = Global.Global.strava.GetClubs();


            return View(new HomeViewModel() { clubs = model, indiv = business.GetUserWithMaxWorkout(), suffer = business.GetUserWithMaxSuffer(), cal= business.GetUserWithMaxCalories() });
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
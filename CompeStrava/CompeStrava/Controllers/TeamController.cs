using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompeStrava.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        //
        // GET: /Team/
        public ActionResult Index(int teamid)
        {
            return View(Global.Global.strava.GetClub(teamid.ToString()));
        }
	}
}
using Strava.Athletes;
using Strava.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompeStrava.Controllers
{
    public class TeamController : Controller
    {
        //
        // GET: /Team/
        public ActionResult Index(int teamid)
        {
            return View(new Tuple<Club, List<AthleteSummary>>(Global.Global.strava.GetClub(teamid.ToString()), Global.Global.strava.GetClubMembers(teamid.ToString())));
        }
	}
}
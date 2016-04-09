using CompeStrava.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompeStrava.Controllers
{
    public class LeaderBoardController : Controller
    {
        //
        // GET: /LeaderBoard/
        public ActionResult Index()
        {
            return View(new LeaderBoardViewModel());
        }
	}
}
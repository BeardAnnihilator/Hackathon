using CompeStrava.Business;
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
        CompestravaBusiness business = new CompestravaBusiness();

        //
        // GET: /LeaderBoard/
        public ActionResult Index()
        {
            var model = business.GetLeaderBoard();
            return View(new LeaderBoardViewModel() { data = model });
        }
	}
}
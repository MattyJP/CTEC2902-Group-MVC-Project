using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Welcome!"] = "Welcome to this shit show";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
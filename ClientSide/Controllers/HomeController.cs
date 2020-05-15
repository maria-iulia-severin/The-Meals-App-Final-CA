using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientSide.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult Menu()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Item()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
    }
}
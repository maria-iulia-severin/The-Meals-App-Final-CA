using ClientSide.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMealsApp.DataModel;

namespace ClientSide.Controllers
{
    public class HomeController : Controller
    {
        private MealsContext _context;

        public HomeController()
        {
            _context = new MealsContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            if (User.IsInRole("StaffMember"))
                return View("Menu");
            else
                return View("ViewOnlyMenu");
        }

        [Authorize(Roles = "StaffMember")]
        public ActionResult NewMenu()
        {
            return View("MenuForm");
        }

        [Authorize(Roles = "StaffMember")]
        public ActionResult EditMenu()
        {
            return View("MenuFormEdit");
        }

        [AllowAnonymous]
        public ActionResult Item()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Exchange()
        {
            return View();
        }

        [Authorize(Roles = "StaffMember")]
        public ActionResult Customer()
        {
            return View();
        }
        [Authorize(Roles ="StaffMember")]
        public ActionResult Order()
        {
            return View();
        }
    }
}
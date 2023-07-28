using AnyWhere____Network_Project_Website.Models;
using AnyWhere____Network_Project_Website.ViewModel;
using AnyWhere___Network_Project_WebSite.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AnyWhere____Network_Project_Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(VM usr)
        {


            return View(usr.user);
        }

        public ActionResult LogedIn(VM usr)
        {

            return RedirectToAction("index", "Home", usr);
        }
    }
}
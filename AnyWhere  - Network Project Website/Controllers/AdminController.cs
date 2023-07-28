using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyWhere____Network_Project_Website.Models;
using AnyWhere___Network_Project_WebSite.Dal;
using AnyWhere____Network_Project_Website.ViewModel;

namespace AnyWhere____Network_Project_Website.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DB db = new DB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserTable()
        {
            VM cvm = new VM
            {
                users = db.users.ToList<Users>()
            };
            return View(cvm);
        }
        public ActionResult FlightTable()
        {
            VM cvm = new VM
            {
                flights = db.flights.ToList<Flights>()
            };
            return View(cvm);
        } 
        public ActionResult BookTable()
        {
            VM cvm = new VM
            {
                books = db.books.ToList<Booking>()
            };
            return View(cvm);
        }
    }
}
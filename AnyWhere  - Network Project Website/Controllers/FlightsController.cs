using AnyWhere____Network_Project_Website.Models;
using AnyWhere____Network_Project_Website.ViewModel;
using AnyWhere___Network_Project_WebSite.Dal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AnyWhere____Network_Project_Website.Controllers
{
    public class FlightsController : Controller
    {
        public static int flight_id = 0;
        public static Flights flig = new Flights();

        [HttpPost]
        public ActionResult Index(VM fvm)
        {
            TempData["SuccessMessage"] = null;
            DateTime date1 = DateTime.ParseExact(fvm.flight.Depart, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            fvm.flight.Depart = date1.ToString("dd/MM/yyyy");
            DateTime date2 = DateTime.ParseExact(fvm.flight.Return, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            fvm.flight.Return = date2.ToString("dd/MM/yyyy");

            flig = fvm.flight;

            using (DB db = new DB())
            {
                //check if enter valid date
                if (!CheckDate(fvm.flight.Depart) && !CheckDate(fvm.flight.Return))
                {
                    fvm.flights = null;
                    return View(fvm);
                }

                //the Main Query
                VM cvm = new VM()
                {
                    flights = (from x in db.flights
                               where x.From == fvm.flight.From && x.To == fvm.flight.To && x.Depart == fvm.flight.Depart && x.Return == fvm.flight.Return
                               select x).ToList<Flights>()
                };
                cvm.flights = FilterDateList(cvm.flights);
                return View(cvm);
            }
        }

        //All Filters  Actions In One
        public ActionResult FlightsFillters(string butn)
        {
            using (DB db = new DB())
            {
                VM cvm = new VM();
                if (butn == null)
                {
                    return View();//send error
                }
                else if (butn == "Price Increase")
                {
                    cvm.flights = (from x in db.flights
                                   where x.From == flig.From && x.To == flig.To && x.Depart == flig.Depart && x.Return == flig.Return
                                   select x).ToList<Flights>();

                    cvm.flights = FilterDateList(cvm.flights);
                    cvm.flights = cvm.flights.OrderBy(p => p.TicketPrice).ToList();
                    return View("Index", cvm);
                }
                else if (butn == "Price Decrease")
                {
                    cvm.flights = (from x in db.flights
                                   where x.From == flig.From && x.To == flig.To && x.Depart == flig.Depart && x.Return == flig.Return
                                   select x).ToList<Flights>();


                    cvm.flights = FilterDateList(cvm.flights);
                    cvm.flights = cvm.flights.OrderByDescending(p => p.TicketPrice).ToList();
                    return View("Index", cvm);
                }
                else if (butn == "NoDirectFlight")
                {
                    cvm.flights = (from x in db.flights
                                   where x.From == flig.From && x.To == flig.To && x.Depart == flig.Depart && x.Return == flig.Return && x.Stops != 0
                                   select x).ToList<Flights>();
                    cvm.flights = FilterDateList(cvm.flights);
                    return View("Index", cvm);
                }
                else if (butn == "DirectFlight")
                {
                    cvm.flights = (from x in db.flights
                                   where x.From == flig.From && x.To == flig.To && x.Depart == flig.Depart && x.Return == flig.Return && x.Stops == 0
                                   select x).ToList<Flights>();
                    cvm.flights = FilterDateList(cvm.flights);
                    return View("Index", cvm);
                }
                else if (butn == "Country Flight")
                {
                    cvm.flights = (from x in db.flights
                                   where x.From == flig.From
                                   select x).ToList<Flights>();
                    cvm.flights = FilterDateList(cvm.flights);
                    return View("Index", cvm);
                }
                else if (butn == "popular Flight")
                {
                    List<int> inputList = new List<int>();

                    List<Flights> fList = new List<Flights>();
                    cvm.books = (from x in db.books
                                 select x).ToList<Booking>();
                    foreach (Booking item in cvm.books)
                    {
                        inputList.Add(item.Flight_id);
                    }

                    var groups = inputList.GroupBy(i => i);
                    var sortedGroups = groups.OrderByDescending(g => g.Count());
                    List<int> outputList = sortedGroups.SelectMany(g => g).ToList();

                    foreach (int item in outputList)
                    {
                        fList.Add(db.flights.Find(item));
                    }
                    cvm.flights = fList;
                    cvm.flights = FilterDateList(cvm.flights);
                    return View("Index", cvm);
                }
                return View("Index");
            }
        }

        //return true if date is update to day
        public bool CheckDate(string c)
        {
            DateTime Fli = DateTime.Parse(c);
            DateTime now = DateTime.Now;
            if (Fli.Date <= now.Date)
                return false;
            return true;
        }

        //this filter after query for remove error dates flights using CheckData Function
        public List<Flights> FilterDateList(List<Flights> list)
        {
            List<Flights> temp = new List<Flights>();
            foreach (Flights flight in list)
            {
                if (CheckDate(flight.Depart) && CheckDate(flight.Return))
                {
                    temp.Add(flight);
                }
            }
            return temp;
        }
        [HttpPost]
        public ActionResult PriceBetween(int price)
        {
            using (DB db = new DB())
            {
                VM cvm = new VM()
                {
                    flights = (from x in db.flights
                               where x.From == flig.From && x.To == flig.To && x.Depart == flig.Depart && x.Return == flig.Return && x.TicketPrice <= price
                               select x).ToList<Flights>()
                };
                cvm.flights = FilterDateList(cvm.flights);
                return View("Index", cvm);
            }
        }
    }
}



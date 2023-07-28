using AnyWhere____Network_Project_Website.ViewModel;
using AnyWhere___Network_Project_WebSite.Dal;
using AnyWhere____Network_Project_Website.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Collections;
using AnyWhere____Network_Project_Website.Models;


namespace AnyWhere____Network_Project_Website.Controllers
{
    public class BookingController : Controller
    {

        // GET: Booking
        public ActionResult BuyTicket(string id)
        {
            string email = AnyWhere____Network_Project_Website.Controllers.UsersController.UserEmail;
            int df_id;
            int.TryParse(id, out df_id);
            using (DB db = new DB())
            {
                var flight = db.flights.SingleOrDefault(f => f.f_Id == df_id);
                VM cvm = new VM() { flight = flight };
                if (email != "")
                {
                    cvm.user = db.users.SingleOrDefault(f => f.Email == email);
                }

                AnyWhere____Network_Project_Website.Controllers.FlightsController.flight_id = cvm.flight.f_Id;
                return View(cvm);
            }
        }

        public ActionResult Purchase(VM fm)
        {
            if (ModelState.IsValid)
            {
                using (DB db = new DB())
                {

                    if (AnyWhere____Network_Project_Website.Controllers.UsersController.UserID == 0)
                    {
                        fm.book.User_id = 0;
                    }
                    else
                    {
                        //search the right user with user id
                        fm.user = db.users.SingleOrDefault(f => f.Id == AnyWhere____Network_Project_Website.Controllers.UsersController.UserID);
                        fm.book.User_id = fm.user.Id;
                    }

                    //search the right flight with flight id
                    fm.flight = db.flights.SingleOrDefault(f => f.f_Id == AnyWhere____Network_Project_Website.Controllers.FlightsController.flight_id);
                    fm.book.Flight_id = AnyWhere____Network_Project_Website.Controllers.FlightsController.flight_id;
                    fm.book.Company = fm.flight.Company;
                    fm.book.From = fm.flight.From;
                    fm.book.To = fm.flight.To;
                    fm.book.Depart = fm.flight.Depart;
                    fm.book.Time_Depart = fm.flight.Time_Depart;
                    fm.book.Return = fm.flight.Return;
                    fm.book.Time_Return = fm.flight.Time_Return;
                    fm.book.Stops = fm.flight.Stops;
                    fm.book.isLowCost = fm.flight.isLowCost;
                    fm.book.TotalPrice = fm.flight.TicketPrice * fm.book.NumberOfTickets;
                }



                //Encrypt For the Cradit card if the user want to save the details
                if (fm.book.WantToStore)
                {
                    byte[] cn = AdvancedEncryption.EncryptAesManaged(fm.book.CardNumber);
                    byte[] ed = AdvancedEncryption.EncryptAesManaged(fm.book.ExpirationDate);
                    byte[] sc = AdvancedEncryption.EncryptAesManaged(fm.book.SecurityCode);

                    fm.book.CardNumber = System.Text.Encoding.UTF8.GetString(cn);
                    fm.book.ExpirationDate = System.Text.Encoding.UTF8.GetString(ed);
                    fm.book.SecurityCode = System.Text.Encoding.UTF8.GetString(sc);
                }
                else
                {
                    fm.book.CardNumber = "None";
                    fm.book.ExpirationDate = "None";
                    fm.book.SecurityCode = "None";
                }

                //random secure number
                using (var rng = new RNGCryptoServiceProvider())
                {
                    var bytes = new byte[4];
                    rng.GetBytes(bytes);
                    fm.book.Id = BitConverter.ToInt32(bytes, 0);
                }

                using (DB db = new DB())
                {
                    db.books.Add(fm.book);
                    db.SaveChanges();
                }

                ModelState.Clear();
            }

            TempData["SuccessMessage"] = "Booking successful!";

            return RedirectToAction("Index","Home", fm);
        }
    }
}
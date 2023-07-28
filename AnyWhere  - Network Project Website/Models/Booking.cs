using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyWhere____Network_Project_Website.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Flight_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Depart { get; set; }
        public string Time_Depart { get; set; }
        public string Return { get; set; }
        public string Time_Return { get; set; }
        public int Stops { get; set; }
        public bool isLowCost { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public bool WantToStore { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
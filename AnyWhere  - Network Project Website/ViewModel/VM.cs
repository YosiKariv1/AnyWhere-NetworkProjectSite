using AnyWhere____Network_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace AnyWhere____Network_Project_Website.ViewModel
{
    public class VM
    {
        public Users user { get; set; }
        public List<Users> users { get; set; }
        public Flights flight { get; set; }
        public List<Flights> flights { get; set; }
        public Booking book { get; set; }
        public List<Booking> books { get; set; }
        public string SelectedFilter { get; set; }
        public string errorMessage { get; set; }
    }
}
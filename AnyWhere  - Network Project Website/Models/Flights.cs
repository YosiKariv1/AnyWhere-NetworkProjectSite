using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AnyWhere____Network_Project_Website.Models
{
    public class Flights
    {

        [Key]
        public int f_Id { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Company Name must be between 3 and 255 latters")]
        public string Company { get; set; }

        [Required(ErrorMessage = "From Country name is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "From Cuntry must be between 3 and 255 latters")]
        public string From { get; set; }

        [Required(ErrorMessage = "To Country name is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "To Cuntry must be between 3 and 255 latters")]
        public string To { get; set; }

        [Required(ErrorMessage = "Depart Date is required")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Depart Date must be between 2 and 255 latters")]
        [RegularExpression(@"^(19|20)\d{2}[-/](0[1-9]|1[012])[-/](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Please enter a valid Date adress")]
        public string Depart { get; set; }

        [Required(ErrorMessage = "Depart time is required")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Depart Time must be between 2 and 255 latters")]
        [RegularExpression(@"^(0?[0-9]|1[0-2]):[0-5][0-9]$", ErrorMessage = "Depart Time must be valide time")]
        public string Time_Depart { get; set; }

        [Required(ErrorMessage = "Return Date is required")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Return Date must be between 2 and 255 latters")]
        [RegularExpression(@"^(19|20)\d{2}[-/](0[1-9]|1[012])[-/](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Please enter a valid Date adress")]
        public string Return { get; set; }

        [Required(ErrorMessage = "Return time is required")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Return Time must be between 2 and 255 latters")]
        [RegularExpression(@"^(0?[0-9]|1[0-2]):[0-5][0-9]$", ErrorMessage = "Return Time must be valide time")]
        public string Time_Return { get; set; }

        [Required(ErrorMessage = "Stops is required")]
        [RegularExpression(@"^(0|1|2)$", ErrorMessage = "Number of Stops must be between 0 and 2 ")]
        public int Stops { get; set; }

        [Required(ErrorMessage = "choose low cost or not is required")]
        public bool isLowCost { get; set; }

        [Required(ErrorMessage = "Number Of sits is required")]
        public int Sits { get; set; }

        [Required(ErrorMessage = "Ticket price is required")]
        public decimal TicketPrice { get; set; }
    }
}
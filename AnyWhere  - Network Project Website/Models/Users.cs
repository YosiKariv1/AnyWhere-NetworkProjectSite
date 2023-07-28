using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnyWhere____Network_Project_Website.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The First Name Field is required.")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 latters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name Field is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "last name must be between 2 and 50 latters")]
        public string LastName { get; set; }

        [Key]
        [Required(ErrorMessage = "The Email Field is required")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Email must be between 2 and 50 latters")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password Field is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "last name must be between 2 and 50 latters")]
        public string Password { get; set; }
    }
}
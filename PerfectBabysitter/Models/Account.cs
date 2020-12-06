using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PerfectBabysitter.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select a birthday")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Please specify a gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select an account type")]
        public string AccountType { get; set; }

        public string Resume { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }

    public enum AccountType
    {
        Babysitter,
        Parent
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PerfectBabysitter.Models
{
    public class SignIn
    {
        [Required(ErrorMessage ="Please select an account type")]
        public string AccountType{get;set;}

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email{get;set;}

        [Required(ErrorMessage ="Please enter a password")]
        public string Password{get;set;}

        public string ReturnUrl { get; set; } = "/";
    }
}

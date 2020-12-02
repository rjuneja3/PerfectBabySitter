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
        public int ID{get;set;}

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName{get;set;}

        public string Password{get;set;}

        [Required]
        public string Birthday{get;set;}

        [Required]
        public string Gender{get;set;}

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email{get;set;}

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber{get;set;}

        [Required]
        public string AccountType{get;set;}

        public byte[] Resume{get;set;}

        public string ReturnUrl { get; set; } = "/";
    }
}

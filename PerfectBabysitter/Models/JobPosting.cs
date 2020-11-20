using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace PerfectBabysitter.Models
{
    public class JobPosting
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber {get;set;}

        [Required(ErrorMessage = "Please enter a email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email {get;set;}

        [Required(ErrorMessage = "Please enter an address")]
        public string Address {get;set;}

        [Required(ErrorMessage = "Please specify the number of children to be looked after")]
        public string Children{get;set;}

        [Required(ErrorMessage = "Please enter when your scheduling for")]
        public string Date{get;set;}

        [Required(ErrorMessage = "Please enter time to start (include am or pm)")]
        public string StartTime{get;set;}

        [Required(ErrorMessage = "Please enter time to end (include am or pm)")]
        public string EndTime{get;set;}

        [Required(ErrorMessage = "Please enter your preferred choice of language")]
        public string Language{get;set;}

        public string Description{get;set;}
    }
}

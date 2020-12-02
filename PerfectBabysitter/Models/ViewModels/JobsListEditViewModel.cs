using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models.ViewModels
{
    public class JobsListEditViewModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Children { get; set; }
        public string Date { get; set; }
        public string DatePosted { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Language { get; set; }
        public bool Cooking { get; set; }
        public bool Cleaning { get; set; }
        public string Activities { get; set; }
        public string Description { get; set; }
    }
}

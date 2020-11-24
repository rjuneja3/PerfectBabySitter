using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectBabysitter.Models;

namespace PerfectBabysitter.Models.ViewModels
{
    public class JobsListViewModel
    {
        public IEnumerable<JobPosting> JobPostings
        {
            get; set;
        }
        public string Keyword { get; set; }

        public bool Cooking { get; set; }

        public bool Cleaning { get; set; }

        public string Activities { get; set; }
        public string Children { get; set; }
    }
}

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
        public string Address { get; set; }
        public int Children { get; set; }
        public string Language { get; set; }
    }
}

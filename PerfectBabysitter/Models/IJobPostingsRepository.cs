using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    interface IJobPostingsRepository
    {
        IQueryable<JobPosting> JobPostings { get; }
    }
}

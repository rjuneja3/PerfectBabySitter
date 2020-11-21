using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    interface IJobPostingsFakeRepository : IJobPostingsRepository
    {
        public IQueryable<JobPosting> JobPostings => new List<JobPosting>
        {
            new JobPosting()
            {
                PhoneNumber ="38728233",
                Email ="Rohansjads@gmail.com",
                Address = "7843 Toronto",
                Children = "2",
                Language = "",
                Description =""

            },
            new JobPosting()
            {
                PhoneNumber ="38748338928233",
                Email ="jkfdjdkf@gmail.com",
                Address = "73 Toronto",
                Children = "2",
                Language = "",
                Description =""

            }
        }.AsQueryable<JobPosting>();
    }
}

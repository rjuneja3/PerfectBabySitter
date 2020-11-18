using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public class EFJobPostingsRepository:IJobPostingsRepository

    {
        private ApplicationDbContext context;
        public EFJobPostingsRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<JobPosting> JobPostings => context.JobPostings;
    }

}

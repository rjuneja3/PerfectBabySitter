using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public class EFAppliedJobRepository : IAppliedJobRepository
    {
        private ApplicationDbContext context;
        public EFAppliedJobRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<AppliedJob> AppliedJobs => context.AppliedJobs;
        public AppliedJob Add(AppliedJob job)
        {
            context.AppliedJobs.Add(job);
            context.SaveChanges();
            return job;
        }
        public void UpdateStatus(AppliedJob job, string status)
        {
            if(job != null)
            {
                AppliedJob jobentry = context.AppliedJobs.Where(r => r.JobId == job.JobId).FirstOrDefault();
                if(jobentry != null)
                {
                    jobentry.Status = status;
                }
            }
            context.SaveChanges();
        }
    }
}

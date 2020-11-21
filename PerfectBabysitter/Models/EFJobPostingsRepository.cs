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

        // sql to add posting
        public void AddPosting(JobPosting jPosting)
        {
                if (jPosting.Id == 0)
                {
                    context.JobPostings.Add(jPosting);
                }
                else
                {
                    JobPosting jobEntry = context.JobPostings
                        .Single(p => p.Id == jPosting.Id);
                    if (jobEntry != null)
                    {
                    jobEntry.Address = jPosting.Address;
                    jobEntry.Children = jPosting.Children;
                    jobEntry.Date = jPosting.Date;
                    jobEntry.Description = jPosting.Description;
                    jobEntry.Email = jPosting.Email;
                    jobEntry.EndTime = jPosting.EndTime;
                    jobEntry.Language = jPosting.Language;
                    jobEntry.PhoneNumber = jPosting.PhoneNumber;
                    jobEntry.StartTime = jPosting.StartTime;
                    }
                }
                context.SaveChanges();
            
        }

        // sql to delete job posting
        public JobPosting DeleteJobPosting(int id)
        {
                JobPosting jobEntry = context.JobPostings
                    .FirstOrDefault(p => p.Id == id);

                if (jobEntry != null)
                {
                    context.JobPostings.Remove(jobEntry);
                    context.SaveChanges();
                }

                return jobEntry;
            
        }
    }

}

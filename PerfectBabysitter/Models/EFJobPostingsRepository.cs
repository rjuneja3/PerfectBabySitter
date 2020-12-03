using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                    var jobEntry = context.JobPostings
                        .Single(p => p.Id == jPosting.Id);
                    if (jobEntry != null)
                    {
                        jobEntry.JobTitle = jPosting.JobTitle;
                        jobEntry.Address = jPosting.Address;
                        jobEntry.Children = jPosting.Children;
                        jobEntry.Date = jPosting.Date;
                        jobEntry.DatePosted = jPosting.DatePosted;
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
                var jobEntry = context.JobPostings
                    .FirstOrDefault(p => p.Id == id);

                if (jobEntry != null)
                {
                    context.JobPostings.Remove(jobEntry);
                    context.SaveChanges();
                }

                return jobEntry;
            
        }

        public JobPosting GetJobPosting(int id)
        {
            var jobEntry = context.JobPostings
                .FirstOrDefault(p => p.Id == id);
            return jobEntry;
        }


        public JobPosting Update(JobPosting jPosting)
        {
            if(context.JobPostings.Find(jPosting.Id) == null)
            {
                context.JobPostings.Update(jPosting);
            }
            else
            {
                var jobEntry = context.JobPostings
                    .FirstOrDefault(p => p.Id == jPosting.Id);
                if (jobEntry != null)
                {
                    jobEntry.JobTitle = jPosting.JobTitle;
                    jobEntry.Address = jPosting.Address;
                    jobEntry.Children = jPosting.Children;
                    jobEntry.Date = jPosting.Date;
                    jobEntry.DatePosted = jPosting.DatePosted;
                    jobEntry.Description = jPosting.Description;
                    jobEntry.Email = jPosting.Email;
                    jobEntry.EndTime = jPosting.EndTime;
                    jobEntry.Language = jPosting.Language;
                    jobEntry.PhoneNumber = jPosting.PhoneNumber;
                    jobEntry.StartTime = jPosting.StartTime;

                }
            }
            context.SaveChanges();
            return jPosting;
        }

    }

}

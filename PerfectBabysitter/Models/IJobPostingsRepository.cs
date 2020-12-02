using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PerfectBabysitter.Models
{
    public interface IJobPostingsRepository
    {
        IQueryable<JobPosting> JobPostings { get; }

        void AddPosting(JobPosting jPosting);
        JobPosting DeleteJobPosting(int id);
        JobPosting GetJobPosting(int id);
        JobPosting Update(JobPosting jPosting);
    }
}

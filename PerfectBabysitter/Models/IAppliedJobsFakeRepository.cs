using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    interface IAppliedJobFakeRepository : IAppliedJobRepository
    {
        public IQueryable<AppliedJob> AppliedJobs => new List<AppliedJob>
        {

       new AppliedJob
                    {
                        ApplicantName = "John Cash",
                        JobId = 1,
                        Status = "Accepeted",
                        AppliedStatus="Applied"
                    },
                    new AppliedJob
                    {
                        ApplicantName = "Jake",
                        JobId = 2,
                        Status = "Declined",
                        AppliedStatus="Applied"

                    }
        }.AsQueryable<AppliedJob>();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectBabysitter.Models
{
    public interface IAppliedJobRepository
    {
        IQueryable<AppliedJob> AppliedJobs { get; }
        AppliedJob Add(AppliedJob job);
        void UpdateStatus(AppliedJob job, string status);
        void UpdateAppliedStatus(AppliedJob job, string status);
        
    }
}

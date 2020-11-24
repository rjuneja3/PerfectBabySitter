using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerfectBabysitter.Models;


namespace PerfectBabysitter.Controllers
{
    public class AppliedJobController : Controller
    {
        private IAppliedJobRepository repository;
        public AppliedJobController(IAppliedJobRepository repo) {
            repository = repo;
        }
        public ActionResult AppliedJobsView()
        {
            return View("AppliedJobsView", repository.AppliedJobs);
        }
    }
}

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
        public ViewResult AppliedJobs()
        {
            return View("~/Views/AppliedJobs/AppliedJobs.cshtml", repository.AppliedJobs);
        }
    }
}

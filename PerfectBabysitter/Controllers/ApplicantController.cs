using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectBabysitter.Models;
using PerfectBabysitter.Models.ViewModels;
using System.Diagnostics;

namespace PerfectBabysitter.Controllers
{
    public class ApplicantController : Controller
    {
        private IAppliedJobRepository repository;
        public ApplicantController(IAppliedJobRepository repo)
        {
            repository = repo;
        }
        
        public ActionResult Applicant()
        {
            return View(repository.AppliedJobs);
        }

    }
}

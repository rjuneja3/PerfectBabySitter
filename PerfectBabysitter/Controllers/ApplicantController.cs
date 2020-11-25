﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public ActionResult Applicant(int jobId, string status)
        {
            AppliedJob aJob = repository.AppliedJobs.FirstOrDefault(j => j.Id == jobId);
            repository.UpdateStatus(aJob, status);
            return View(repository.AppliedJobs);
        }


    }
}

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
        //add repo/db for Applicant/Account

        public ApplicantController(IAppliedJobRepository repo)
        {
            repository = repo;
        }
        
        public ActionResult Applicant()
        {
            return View(repository.AppliedJobs);
        }

        public ViewResult ApplicantList() 
        {
            return View("~/Views/ApplicantList/ApplicantList.cshtml", repository.AppliedJobs);
        }

        public ViewResult AppliedJobs() 
        {
            return View("~/Views/Applicant/AppliedJobs.cshtml", repository.AppliedJobs);
        }

        [HttpPost]
        public ActionResult Applicant(int jobId, string status)
        {
            AppliedJob aJob = repository.AppliedJobs.FirstOrDefault(j => j.Id == jobId);
            repository.UpdateStatus(aJob, status);
            return View(repository.AppliedJobs);
        }

        [HttpPost]
        public ActionResult AppliedJobs(int jobId, string status)
        {
            AppliedJob aJob = repository.AppliedJobs.FirstOrDefault(j => j.Id == jobId);
            repository.UpdateAppliedStatus(aJob, status);
            return View(repository.AppliedJobs);
        }

        public ActionResult Details(int Id)  
        {  
            //replace commented code with what you use to access Applicant database (when repo is setup)

            /*Info info = new Info();  
            info = db.Info.Find(Id);
            return PartialView("ApplicantDetails",info);  */
            return PartialView("ApplicantDetails");
        }  

    }
}

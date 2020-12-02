using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerfectBabysitter.Models;
using PerfectBabysitter.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Update;

namespace PerfectBabysitter.Controllers
{
    public class PostJobController : Controller
    {

        private IJobPostingsRepository repository;

        public PostJobController(IJobPostingsRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ViewResult JobForm()
        {
            JobPosting job = new JobPosting();
            return View(job);
        }

        
        [HttpPost]
        public ActionResult JobForm(JobPosting job)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(CompletedForm));
            }

            return View(job);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            JobPosting posting = repository.GetJobPosting(id);
            JobsListEditViewModel job = new JobsListEditViewModel
            {
                Id = posting.Id,
                JobTitle = posting.JobTitle,
                PhoneNumber = posting.PhoneNumber,
                Email = posting.Email,
                Address = posting.Address,
                Children = posting.Children,
                Date = posting.Date,
                DatePosted = posting.DatePosted,
                StartTime = posting.StartTime,
                EndTime = posting.EndTime,
                Language = posting.Language,
                Cooking = posting.Cooking,
                Cleaning = posting.Cleaning,
                Activities = posting.Activities,
                Description = posting.Description

            };
            return View(job);
        }

        [HttpPost]
        public ActionResult Edit(JobPosting model)
        {
            if (ModelState.IsValid)
            {
                var posting = repository.GetJobPosting(model.Id);
                posting.Id = model.Id;
                posting.JobTitle = model.JobTitle;
                posting.PhoneNumber = model.PhoneNumber;
                posting.Email = model.Email;
                posting.Address = model.Address;
                posting.Children = model.Children;
                posting.Date = model.Date;
                posting.DatePosted = model.DatePosted;
                posting.StartTime = model.StartTime;
                posting.EndTime = model.EndTime;
                posting.Language = model.Language;
                posting.Cooking = model.Cooking;
                posting.Cleaning = model.Cleaning;
                posting.Activities = model.Activities;
                posting.Description = model.Description;
            }
            JobPosting updatePosting = repository.Update(model);
            return RedirectToAction(nameof(CompletedEdit));
        }

        public ViewResult CompletedEdit()
        {
            ViewBag.CompleteMessage = "Your posting has been successfully updated!";
            return View();
        }
        public ViewResult CompletedForm()
        {
            ViewBag.CompleteMessage = "Your job posting has been uploaded!";
            return View();
        }
        public ActionResult ViewJobs()
        {
            return View("ViewJobs", repository.JobPostings);
        }

        public ViewResult PostedJobs()
        {
            return View("PostedJobs", repository.JobPostings);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectBabysitter.Models;

namespace PerfectBabysitter.Controllers
{
    public class PostJobController : Controller
    {
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

        public ViewResult CompletedForm()
        {
            ViewBag.CompleteMessage = "Your job posting has been uploaded.";
            return View();
        }
    }
}

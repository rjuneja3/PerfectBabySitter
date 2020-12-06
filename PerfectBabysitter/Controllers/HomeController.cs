using Microsoft.AspNetCore.Mvc;
using PerfectBabysitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PerfectBabysitter.Controllers
{
    public class HomeController : Controller
    {
        IJobPostingsRepository postRepository;
        public HomeController(IJobPostingsRepository postRepo)
        {
            postRepository = postRepo;
        }

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

      

        // get details of job according to id
        public ActionResult GetJob(int id)
        {
            //sql to display job details on basis of id
            JobPosting j = postRepository.JobPostings.Single(p => p.Id == id);
            return View(j);
        }

  
        [HttpGet]
        public ViewResult EditJobPosting(int id)
        {
            return View(postRepository.JobPostings.Single(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult EditJobPosting(JobPosting jPosting, IEnumerable<int> checkResponse)
        {
            if (ModelState.IsValid)
            {
                // method needs to be implemented in repository
                postRepository.AddPosting(jPosting);
                return RedirectToAction("Index");
            }
            else
            {
                return View(jPosting);
            }
        }

        public IActionResult JobPosting(int id)
        {
            // temp 
            JobPosting deletedJobPosting = postRepository.DeleteJobPosting(id);

            return RedirectToAction("Index");
        }
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }
            return View("404");
        }
        public ActionResult ContactUs()
        {
            return View("ContactUs");
        }
        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
        public ActionResult PrivacyPolicy()
        {
            return View("PrivacyPolicy");
        }
    }

}

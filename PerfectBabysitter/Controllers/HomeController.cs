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
    }
    
}

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
    public class SearchController : Controller
    {
        private IJobPostingsRepository repository;
        public SearchController(IJobPostingsRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ViewResult SearchResults()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SearchResults(JobsListViewModel j)
        {

            ViewBag.Title = "Search Results";
            JobsListViewModel result = new JobsListViewModel();
            Debug.WriteLine(j.Keyword);
            if (j.Keyword == "" || j.Keyword == null)
            {
                result.JobPostings = repository.JobPostings.Where(r => (r.Activities).Contains(j.Activities) || (r.Cleaning == j.Cleaning) || (r.Cooking == j.Cooking) || (r.Children == j.Children)).OrderBy(r => r.Id);
            }
            else
            {
                result.JobPostings = repository.JobPostings.Where(r => (j.Keyword == null) || (r.Address.Contains(j.Keyword)) ||
                (r.Language.Contains(j.Keyword)) || (r.Activities).Contains(j.Activities) || (r.Cleaning == j.Cleaning) || (r.Cooking == j.Cooking) || (r.Children == j.Children)).OrderBy(r => r.Id);
            }

            result.Keyword = j.Keyword;

            return View("SearchResults", result);
        
        }
    }
}

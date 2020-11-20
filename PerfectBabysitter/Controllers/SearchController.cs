using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectBabysitter.Models;
using PerfectBabysitter.Models.ViewModels;

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
        public ViewResult SearchResults(string address, string language)
        {
            ViewBag.Title = "Search Results";
            return View("SearchResults", new JobsListViewModel
            {
                JobPostings = repository.JobPostings.Where(r => (address == null) || (language == null) || (r.Address.Contains(address)) ||
                (r.Language.Contains(language))).OrderBy(r => r.Id)
            }
        );

        }
    }
}

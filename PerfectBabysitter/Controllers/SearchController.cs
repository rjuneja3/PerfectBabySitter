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
        public ViewResult SearchAddress(string address)
        {

            ViewBag.Title = "Search Results";
            var results = from jobs in repository.JobPostings select jobs;
            if (!string.IsNullOrEmpty(address))
            {
                results = results.Where(r => r.Address.Contains(address));
            }
            else
            {
                results = results.OrderBy(r => r.Id);
            }
            JobsListViewModel jobListVM = new JobsListViewModel();
            jobListVM.JobPostings = results;
            jobListVM.Address = address;
            return View("SearchResults", jobListVM);

        }

        [HttpGet]
        public ViewResult SearchResults(string address, int children, bool householdDuties, bool cooking, bool cleaning, string activities)
        {

            ViewBag.Title = "Search Results";
            var results = from jobs in repository.JobPostings select jobs;
            if (!string.IsNullOrEmpty(address))
            {
                results = results.Where(r => r.Address.Contains(address));
            }
            if (!string.IsNullOrEmpty(children.ToString()) || children >= 1)
            {
                results = results.Where(r => r.Children <= children);
            }

            if (householdDuties != null && householdDuties == true)
            {
                if (!string.IsNullOrEmpty(cooking.ToString()))
                {
                    results = results.Where(r => r.Cooking == cooking);
                }
                if (!string.IsNullOrEmpty(cleaning.ToString()))
                {
                    results = results.Where(r => r.Cleaning == cleaning);
                }
            }
            else if (householdDuties != null && householdDuties == false)
            {
                results = results.Where(r => r.Cleaning == false && r.Cooking == false);
            }

            if (!string.IsNullOrEmpty(activities))
            {
                results = results.Where(r => r.Activities.Contains(activities));
            }
            JobsListViewModel jobListVM = new JobsListViewModel();
            jobListVM.JobPostings = results;
            jobListVM.Address = address;
            jobListVM.Children = children.ToString();
            jobListVM.Cooking = cooking;
            jobListVM.Cleaning = cleaning;
            jobListVM.Activities = activities;
            return View("SearchResults", jobListVM);

        }
    }
}

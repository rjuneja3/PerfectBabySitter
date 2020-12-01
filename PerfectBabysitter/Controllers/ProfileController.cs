using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectBabysitter.Controllers
{
    public class ProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        public IActionResult Register()
        {
            return View("Register");
        }
    }
}

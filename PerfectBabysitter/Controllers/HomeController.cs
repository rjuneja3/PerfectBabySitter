using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace PerfectBabysitter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

    }
    
}

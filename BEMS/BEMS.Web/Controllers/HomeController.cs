using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using BEMS.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class HomeController : Controller
    {
        [LoginNeeded]
        public IActionResult Index()
        {
            return View();
        }        
              
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult Login()
        {
            ViewBag.SiteName = GlobalBusiness.GetSiteName();
            return View();
        }        
    }
}
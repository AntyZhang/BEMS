using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAccount()
        {
            return null;
        }

        public IActionResult DisableAccount()
        {
            return null;
        }
        public IActionResult EnableAccount()
        {
            return null;
        }


    }
}
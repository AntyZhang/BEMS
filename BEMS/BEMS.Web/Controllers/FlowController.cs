using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class FlowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormsCreatedByMe()
        {
            return null;
        }
        public IActionResult FormsUnderMe()
        {
            return null;
        }
        public IActionResult FromsApprovedByMe()
        {
            return null;
        }



    }
}
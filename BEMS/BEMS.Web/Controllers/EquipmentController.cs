using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminView()
        {
            return View();
        }
        public IActionResult GeneralView()
        {
            return View();
        }

        public IActionResult AddEquipment()
        {
            return null;
        }

    }
}
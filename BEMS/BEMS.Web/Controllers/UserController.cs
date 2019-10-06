using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoadAllUser()
        {
            var list = UserBAL.GetAllUsers();

            return Json(list);
        }
    }
}
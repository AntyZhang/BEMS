using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using BEMS.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace BEMS.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login([FromBody] dynamic login)
        {
            try
            {
                String userName = login.UserName;
                String pwd = login.Pwd;
                UserModel user = UserBAL.CheckLogin(userName, pwd);
                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
                return new JsonResult(new { Flag = true });
                //return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Flag = false, Message = ex.Message });
            }
        }
    }
}
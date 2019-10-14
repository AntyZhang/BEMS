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
    public class AccountController : BasicController
    {
        public IActionResult Login()
        {
            ViewBag.SiteName = GlobalBusiness.GetSiteName();
            return View();
        }
        public IActionResult CheckLogin([FromBody] dynamic login)
        {
            try
            {
                String userName = login.UserName;
                String pwd = login.Pwd;
                UserModel user = UserBAL.CheckLogin(userName, pwd);
                _CurrentUser = user;
                return new JsonResult(new { Flag = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Flag = false, Message = ex.Message });
            }
        }

        public IActionResult GetCurrentUser()
        {
            try
            {
                return new JsonResult(new { DisplayName = _CurrentUser.DisplayName, AccountName = _CurrentUser.AccountName });
            }
            catch (Exception)
            {
                return new RedirectResult("/Account/Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
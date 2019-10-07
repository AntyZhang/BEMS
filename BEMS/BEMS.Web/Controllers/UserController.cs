using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using BEMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace BEMS.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoadAllUser()
        {
            var list = UserBAL.GetAllUsers();

            return Json(list);
        }
        public IActionResult SaveUserProfile([FromBody] dynamic postData)
        {
            try
            {
                var userData = postData.data;
                UserModel currentUser;
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
                {
                    currentUser = new UserModel()
                    {
                        ID = 1,
                        AccountName = "admin"
                    };
                }
                else
                {
                    currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("CurrentUser"));
                }

                var user = new UserModel()
                {
                    AccountName = userData.AccountName,
                    Address = userData.Address,
                    DisplayName = userData.DisplayName,
                    Memo = userData.Memo,
                    Phone = userData.Phone,
                    State = userData.State

                };
                if (!user.ID.HasValue)
                {
                    user.ID = null;
                    user.CreateBy = currentUser.AccountName;
                    user.CreateTime = DateTime.Now;
                    user.LastModifyBy = null;
                    user.LastModifyTime = null;
                }
                else
                {
                    user.ID = userData.ID;
                    user.LastModifyBy = currentUser.AccountName;
                    user.LastModifyTime = DateTime.Now;
                }

                UserBAL.SaveUserProfile(user);
                return Json(new { Flag = true, Message = string.Empty });
            }
            catch (Exception ex)
            {
                return Json(new { Flag = false, Message = ex.Message });
            }
        }

    }
}
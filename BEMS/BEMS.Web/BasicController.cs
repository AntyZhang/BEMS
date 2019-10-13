using BEMS.Common;
using BEMS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEMS.Web
{
    public class BasicController : Controller
    {
        private UserModel _CurrentUser;
        public UserModel CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                {
                    if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
                    {
                        _CurrentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("CurrentUser"));
                        return _CurrentUser;
                    }
                    else
                    {
                        throw new Exception("请重新登录！");
                    }
                }
                else
                {
                    return _CurrentUser;
                }
            }
            set
            {
                _CurrentUser = value;
                if (value == null)
                {
                    HttpContext.Session.Clear();
                }
                else
                {
                    HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(value));
                }
            }
        }

        public int PerPage
        {
            get
            {
                return Convert.ToInt32(AppConfiguration.Configuration["Appsettings:PerPage"]);
            }
        }
    }
}

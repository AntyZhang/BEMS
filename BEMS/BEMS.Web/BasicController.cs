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
        private UserModel _currentUser;

        protected UserModel _CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
                    {
                        _currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("CurrentUser"));
                        return _currentUser;
                    }
                    else
                    {
                        throw new Exception("请重新登录！");
                    }
                }
                else
                {
                    return _currentUser;
                }
            }
            set
            {
                _currentUser = value;
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

        protected int _PerPage
        {
            get
            {
                return Convert.ToInt32(AppConfiguration.Configuration["Appsettings:PerPage"]);
            }
        }
    }
}

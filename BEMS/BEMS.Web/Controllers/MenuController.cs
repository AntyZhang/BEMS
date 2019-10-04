﻿using BEMS.BAL;
using BEMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEMS.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult GetAllMenus()
        {
            var menuList = MenuBAL.GetMenus();
            //var menuList = new List<MenuModel>();
            //menuList.Add(new MenuModel()
            //{
            //    Title = "我的",
            //    Active = true,
            //    MenuItems = new List<MenuItem>()
            //    {
            //        new MenuItem(){
            //            Name ="我的单据",
            //            Link ="/flow",
            //            Selected =true
            //        }
            //    }
            //});

            //menuList.Add(new MenuModel()
            //{
            //    Title = "单据",
            //    Active = false,
            //    MenuItems = new List<MenuItem>()
            //    {
            //        new MenuItem(){
            //            Name ="设备申领",
            //            Link ="/flow/NewEqRequest",
            //            Selected =false
            //        },
            //        new MenuItem(){
            //            Name ="报废申请",
            //            Link ="/flow/ScrapEqRequest",
            //            Selected =false
            //        },
            //        new MenuItem(){
            //            Name ="资产转移",
            //            Link ="/flow/EqTransRequest",
            //            Selected =false
            //        }

            //    }
            //});
            //menuList.Add(new MenuModel()
            //{
            //    Title = "资产查看",
            //    Active = false,
            //    MenuItems = new List<MenuItem>()
            //    {
            //        new MenuItem(){
            //            Name ="资产一览",
            //            Link ="/equipment",
            //            Selected =false
            //        }
            //    }
            //});

            return new JsonResult(menuList);
        }
    }
}

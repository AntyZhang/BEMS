using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.IO;
using Newtonsoft.Json;
using BEMS.Web.Models;

namespace BEMS.Web.Controllers
{
    public class EquipmentController : Controller
    {
        [Authorize]
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

        //[Authorize]
        public IActionResult LoadData([FromBody] PaginationModel pageModel)
        {
            //var data = Request.Form;
            //var newPage = Convert.ToInt32(data["GotoPage"]);
            var newPage = pageModel.NewPage - 1;

            var list = new List<dynamic>()
            {
                new  { ID= 001, EType= "打印机", Vendor= "斑马", EModel= "B-123456", SeriaNumber= "98932823", IP= "127.0.0.1", MAC= "SSOSS", LimitedUseage= "5(年)", Owner= "张三", Address= "南京路120号", IsInUse= "是" },
                new  { ID= 002, EType= "打印机", Vendor= "HP", EModel= "hp-987456", SeriaNumber= "25665236", IP= "192.0.0.1", MAC= "ppppssd", LimitedUseage= "12(月)", Owner= "张三", Address= "南京路120号", IsInUse= "是" }
            };

            for (int i = 0; i < 500; i++)
            {
                var item = new { ID = i, EType = "打印机" + i, Vendor = "斑马" + i, EModel = "B" + new Random().Next(), SeriaNumber = "S" + new Random(i).Next(), IP = "127.0.0." + i, MAC = "SSOSS" + i, LimitedUseage = i + "(年)", Owner = "张三" + i.ToString(), Address = "南京路120号", IsInUse = "是" };
                list.Add(item);
            }
            //list.Where("");
            list = list.Skip(newPage * 20).Take(20).ToList();

            var setting = new Newtonsoft.Json.JsonSerializerSettings();
            setting.ContractResolver = new DefaultContractResolver();

            return new JsonResult(list, setting);
        }
    }

}
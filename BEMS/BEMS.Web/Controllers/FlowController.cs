using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.Model;
using BEMS.Web.Models;
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

        public IActionResult NewEqRequest()
        {
            return null;
        }

        public IActionResult CreateNewEqRequest([FromBody] dynamic data)
        {
            var model = new NewEqRequestModel()
            {
                Amount = data.Amount,
                EquipmentNO = data.EquipmentNO,
                EquipmentType = data.EquipmentType,
                Memo = data.Memo,
                Requester = data.Requester,
                RequestTime = data.RequestTime
            };



            return new JsonResult(new
            {
                Flag = true,
                Message = ""
            }); ;
        }

        public IActionResult ScrapEqRequest()
        {
            return null;
        }

        public IActionResult EqTransferRequest()
        {
            return null;
        }
        public IActionResult LoadData([FromBody] FlowFilterModel filterModel)
        {
            var newPage = filterModel.NewPage - 1;
            var isInProgress = filterModel.IsInProgress;

            var list = new List<dynamic>()
            {
                new  { ID= 001, FlowType= "物品申领单", Applicant= "张三", RequestDate= DateTime.Now, Status="进行中" }

            };

            for (int i = 2; i < 200; i++)
            {
                Random random = new Random((int)(DateTime.Now.Ticks));

                int hour = random.Next(2, 5);
                int minute = random.Next(0, 60);
                int second = random.Next(0, 60);
                string tempStr = string.Format("{0} {1}:{2}:{3}", DateTime.Now.ToString("yyyy-MM-dd"), hour, minute, second);
                DateTime rTime = Convert.ToDateTime(tempStr);
                var item = new { ID = i, FlowType = isInProgress ? "待审批" : "已审批" + "物品申领单", Applicant = "张三", RequestDate = rTime, Status = "Stauts" + hour };
                list.Add(item);
            }
            //list.Where("");
            list = list.Skip(newPage * 20).Take(20).ToList();


            return new JsonResult(list);
        }
    }
}
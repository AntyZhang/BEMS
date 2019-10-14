using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEMS.BAL;
using BEMS.Model;
using BEMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class FlowController : BasicController
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


        public IActionResult CreateNewEqRequest([FromBody] dynamic data)
        {
            var model = new NewEqRequestModel()
            {
                Amount = data.Amount,
                EModel = data.EModel,
                EType = data.EType,
                Memo = data.Memo,
                Requester = data.Requester,
                RequestTime = data.RequestTime                
            };
            try
            {
                NewEqRequestFlow.CreateNew(model);
                return new JsonResult(new
                {
                    Flag = true,
                    Message = ""
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    Flag = false,
                    Message = e.Message
                });
            }
        }

        public IActionResult ApproveNewEQRequest([FromBody] dynamic data)
        {
            string ticketID = data.TicketNo;
            string comments = data.Comments;

            try
            {
                FlowBAL.ApproveNewEQRequest(ticketID, _CurrentUser.AccountName, comments);
                return new JsonResult(new
                {
                    Flag = true,
                    Message = string.Empty
                });
            }
            catch (Exception e)
            {

                return new JsonResult(new
                {
                    Flag = false,
                    Message = e.Message
                });
            }
        }

        public IActionResult ScrapEqRequest()
        {
            return null;
        }

        public IActionResult EqTransferRequest()
        {
            return null;
        }
        public IActionResult LoadMyTicket([FromBody] dynamic filterModel)
        {
            int newPage = filterModel.NewPage - 1;
            bool isCreateByMe = filterModel.IsCreateByMe;
            List<TicketSummaryModel> list;
            if (isCreateByMe)
            {
                list = FlowBAL.GetTicketCreateByMe(base._CurrentUser.AccountName, newPage, _PerPage);
            }
            else
            {
                list = FlowBAL.GetTicketNeedMyApprove(base._CurrentUser.AccountName, newPage, _PerPage);
            }

            return new JsonResult(new { Data = list, PageCount = Math.Ceiling(Convert.ToDecimal(list.Count / (_PerPage * 1.0f))) });
        }

        public IActionResult GetOneNEWEQTicket([FromBody] dynamic data)
        {
            try
            {
                string id = data.ID;
                var ticket = FlowBAL.GetSingleNEWEQRequestByTickeyNo(id);
                return new JsonResult(new { Flag = true, Data = ticket });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Flag = false, Message = ex.Message });
            }

        }
    }
}
using BEMS.DAL.EF;
using BEMS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BEMS.DAL
{
    public class FlowDAL
    {
        public static void CreateNewEqRequest(NewEqRequestModel model)
        {
            using (var context = new BEMSContext())
            {
                context.FlowNewEqRequests.Add(new EF.DBModels.FlowNewEqRequest()
                {
                    ID = "NEWEQ_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Amount = model.Amount,
                    EquipmentNO = model.EquipmentNO,
                    EquipmentType = model.EquipmentType,
                    Memo = model.Memo,
                    Requester = model.Requester,
                    RequestTime = model.RequestTime,
                    CurrentFlowIndex = model.CurrentFlowIndex,
                    IsComplete = model.IsComplete,
                    Assignee = model.Assignee
                });
                context.SaveChanges();
            }
        }

        public static FlowDefineModel GetFlowDefine(string flowType)
        {
            using (var context = new BEMSContext())
            {
                var flowDefine = context.FlowDefines.SingleOrDefault(a => a.FlowType.Equals(flowType));
                return new FlowDefineModel()
                {
                    Creator = flowDefine.Creator,
                    CreatTime = flowDefine.CreatTime,
                    FlowType = flowDefine.FlowType,
                    ID = flowDefine.ID,
                    Steps = JsonConvert.DeserializeObject<List<FlowDefineStep>>(flowDefine.FlowStepDefine)
                };
            }
        }

        public static void ApproveNEWEQRequest(NewEqRequestModel model)
        {

        }

        public static void ApproveScrapQRequest(NewEqRequestModel model)
        {


        }

        public static NewEqRequestModel GetSingleNEWEQRequestByTickeyNo(string ticketNo)
        {
            using (var context = new BEMSContext())
            {
                var ticket = context.FlowNewEqRequests.SingleOrDefault(a => a.ID.Equals(ticketNo));
                return new NewEqRequestModel()
                {
                    Amount = ticket.Amount,
                    Assignee = ticket.Assignee,
                    CurrentFlowIndex = ticket.CurrentFlowIndex,
                    EquipmentNO = ticket.EquipmentNO,
                    EquipmentType = ticket.EquipmentType,
                    IsComplete = ticket.IsComplete,
                    Memo = ticket.Memo,
                    Requester = ticket.Requester,
                    RequestTime = ticket.RequestTime
                };

            }
        }
    }
}

using BEMS.DAL;
using BEMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BEMS.BAL
{
    public class FlowBAL
    {
        public static FlowDefineModel GetFlowDefine(string flowType)
        {
            return FlowDAL.GetFlowDefine(flowType);
        }

        public static FlowDefineStep MoveToNextFlowStep(int currentIndex, FlowDefineModel flowDefine)
        {
            var nextFlowSteps = flowDefine.Steps.Where(a => a.Index > currentIndex).OrderBy(a => a.Index);
            if (nextFlowSteps == null)
            {
                return null;
            }
            else
            {
                return nextFlowSteps.FirstOrDefault();
            }
        }

        public static void ApproveFlow(string flowType, string ticketNo, string currentUser)
        {
            try
            {
                var flowDefine = GetFlowDefine(flowType);
                switch (flowType)
                {
                    case "NEWEQ":
                        ApproveNewEQRequest(ticketNo, currentUser, flowDefine);
                        break;
                    case "SCRAPEQ":
                        ApproveScrapEQRequest(ticketNo, currentUser, flowDefine);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void ApproveNewEQRequest(string ticketNo, string currentUser, FlowDefineModel flowDefine)
        {
            var ticket = FlowDAL.GetSingleNEWEQRequestByTickeyNo(ticketNo);
            var currentStep = flowDefine.Steps.SingleOrDefault(a => a.Index == ticket.CurrentFlowIndex);
            var nextStep = MoveToNextFlowStep(currentStep.Index, flowDefine);

            if (currentStep.Owner.Equals(ticket.Assignee))
            {
                if (nextStep == null)
                {
                    var ticketComplete = new NewEqRequestModel()
                    {
                        Assignee = null,
                        CurrentFlowIndex = null,
                        IsComplete = true
                    };
                    FlowDAL.ApproveNEWEQRequest(ticketComplete);
                }
                else
                {
                    var ticketUpdate = new NewEqRequestModel()
                    {
                        Assignee = nextStep.Owner,
                        CurrentFlowIndex = nextStep.Index,
                        IsComplete = false
                    };
                    FlowDAL.ApproveNEWEQRequest(ticketUpdate);
                }
            }
            else
            {
                throw new Exception("审批人信息不正确！");
            }
        }
        private static void ApproveScrapEQRequest(string ticketNo, string currentUser, FlowDefineModel flowDefine)
        {

        }
    }
}

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

        public static void ApproveNewEQRequest(string ticketID, string currentUser, string strComments)
        {
            try
            {
                var flowDefine = GetFlowDefine("NEWEQ");
                var ticket = FlowDAL.GetSingleNEWEQRequestByTickeyNo(ticketID);
                var currentStep = flowDefine.Steps.SingleOrDefault(a => a.Index == ticket.CurrentFlowIndex);
                var nextStep = MoveToNextFlowStep(currentStep.Index, flowDefine);

                if (currentStep.Owner.Equals(ticket.Assignee))
                {
                    if (nextStep == null)
                    {
                        var ticketComplete = new NewEqRequestModel()
                        {
                            ID = ticketID,
                            Assignee = null,
                            CurrentFlowIndex = null,
                            IsComplete = true,
                            Comments = strComments,
                            LastModifyBy = currentUser,
                            LastModifyTime = DateTime.Now
                        };
                        FlowDAL.ApproveNEWEQRequest(ticketComplete);
                    }
                    else
                    {
                        var ticketUpdate = new NewEqRequestModel()
                        {
                            ID = ticketID,
                            Assignee = nextStep.Owner,
                            CurrentFlowIndex = nextStep.Index,
                            IsComplete = false,
                            Comments = strComments,
                            LastModifyBy = currentUser,
                            LastModifyTime = DateTime.Now
                        };
                        FlowDAL.ApproveNEWEQRequest(ticketUpdate);
                    }
                }
                else
                {
                    throw new Exception("审批人信息不正确！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void ApproveScrapEQRequest(string ticketNo, string currentUser, FlowDefineModel flowDefine, string strComments)
        {

        }

        public static List<TicketSummaryModel> GetTicketNeedMyApprove(string user, int page, int perpage)
        {
            return FlowDAL.GetTicketNeedMyApprove(user, page, perpage);
        }

        public static List<TicketSummaryModel> GetTicketCreateByMe(string user, int page, int perpage)
        {
            return FlowDAL.GetTicketCreateByMe(user, page, perpage);
        }

        public static NewEqRequestModel GetSingleNEWEQRequestByTickeyNo(string ticketNO)
        {
            try
            {
                return FlowDAL.GetSingleNEWEQRequestByTickeyNo(ticketNO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void GetTicketApprovedByMe()
        {

        }
    }
}

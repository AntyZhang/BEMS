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
                model.ID = "NEWEQ_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                context.FlowNewEqRequests.Add(new EF.DBModels.FlowNewEqRequest()
                {
                    ID = model.ID,
                    Amount = model.Amount,
                    EModel = model.EModel,
                    EType = model.EType,
                    Memo = model.Memo,
                    Requester = model.Requester,
                    RequestTime = model.RequestTime,
                    IsComplete = model.IsComplete
                });

                context.FlowProgress.Add(new EF.DBModels.FlowProgress
                {
                    FlowType = "NEWEQ",
                    Assignee = model.Assignee,
                    AssignTime = model.RequestTime,
                    Comments = string.Empty,
                    CurrentFlowStep = model.CurrentFlowIndex.Value,
                    TicketID = model.ID,
                    LastUpdateBy = model.Requester,
                    LastUpdateTime = model.RequestTime

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
            using (var context = new BEMSContext())
            {

                if (model.IsComplete == true)
                {
                    var ticket = context.FlowNewEqRequests.SingleOrDefault(a => a.ID.Equals(model.ID));
                    if (ticket == null)
                    {
                        throw new NullReferenceException(string.Format("单据未找到。ID:{0}。", model.ID));
                    }
                    ticket.IsComplete = true;
                }
                else
                {
                    var ticketFlow = context.FlowProgress.SingleOrDefault(a => a.TicketID.Equals(model.ID));
                    ticketFlow.Assignee = model.Assignee;
                    ticketFlow.AssignTime = DateTime.Now;
                    ticketFlow.CurrentFlowStep = model.CurrentFlowIndex.Value;
                    ticketFlow.Comments = model.Comments;
                    ticketFlow.LastUpdateBy = model.LastModifyBy;
                    ticketFlow.LastUpdateTime = model.LastModifyTime.Value;
                }

                context.SaveChanges();
            }
        }

        public static void ApproveScrapQRequest(NewEqRequestModel model)
        {


        }

        public static NewEqRequestModel GetSingleNEWEQRequestByTickeyNo(string ticketID)
        {
            using (var context = new BEMSContext())
            {

                var ticket = (from t in context.FlowNewEqRequests
                              join progress in context.FlowProgress on t.ID equals progress.TicketID
                              where t.ID.Equals(ticketID)
                              select new NewEqRequestModel()
                              {
                                  ID = t.ID,
                                  Amount = t.Amount,
                                  Assignee = progress.Assignee,
                                  CurrentFlowIndex = progress.CurrentFlowStep,
                                  EModel = t.EModel,
                                  EType = t.EType,
                                  IsComplete = t.IsComplete,
                                  Memo = t.Memo,
                                  Requester = t.Requester,
                                  RequestTime = t.RequestTime
                              }).FirstOrDefault();

                if (ticket == null)
                {
                    throw new NullReferenceException(string.Format("单号：{0}未找到！", ticketID));
                }
                return ticket;
            }
        }

        public static List<TicketSummaryModel> GetTicketNeedMyApprove(string user, int page, int perpage)
        {
            using (var context = new BEMSContext())
            {
                var list = (from ticket in context.FlowNewEqRequests
                            join history in context.FlowProgressHistory on ticket.ID equals history.TicketID
                            where history.ActionBy.Equals(user)
                            select new TicketSummaryModel
                            {
                                ID = ticket.ID,
                                FlowType = "NEWEQ",
                                IsComplete = ticket.IsComplete,
                                RequestDate = ticket.RequestTime,
                                Requester = ticket.Requester
                            }).Skip(page * perpage).Take(perpage);
                return list.ToList();
            }
        }
        public static List<TicketSummaryModel> GetTicketCreateByMe(string user, int page, int perpage)
        {
            using (var context = new BEMSContext())
            {
                var list = (from ticket in context.FlowNewEqRequests
                            where ticket.Requester.Equals(user)
                            select new TicketSummaryModel
                            {
                                ID = ticket.ID,
                                FlowType = "NEWEQ",
                                IsComplete = ticket.IsComplete,
                                RequestDate = ticket.RequestTime,
                                Requester = ticket.Requester
                            }).Skip(page * perpage).Take(perpage);
                return list.ToList();
            }
        }


    }
}

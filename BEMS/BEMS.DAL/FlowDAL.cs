using BEMS.DAL.EF;
using BEMS.Model;
using System;

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
                    FlowIndex = model.FlowIndex,
                    IsComplete = model.IsComplete
                });
                context.SaveChanges();
            }
        }

        public void GetFlow()
        {

        }
    }
}

using BEMS.DAL;
using BEMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.BAL
{
    public class NewEqRequestFlow
    {

        public NewEqRequestFlow()
        {

        }

        public static void CreateNew(NewEqRequestModel model)
        {
            try
            {
                var flowDefine = FlowBAL.GetFlowDefine("NEWEQ");
                model.CurrentFlowIndex = 0;

                var nextStep = FlowBAL.MoveToNextFlow(model.CurrentFlowIndex, flowDefine);
                if (nextStep != null)
                {
                    model.CurrentFlowIndex = nextStep.Index;
                    model.Assignee = nextStep.Owner;
                    model.IsComplete = false;
                }
                else
                {
                    model.IsComplete = true;
                }

                FlowDAL.CreateNewEqRequest(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

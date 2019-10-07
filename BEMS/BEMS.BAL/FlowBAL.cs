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

        public static FlowDefineStep MoveToNextFlow(int currentIndex, FlowDefineModel flowDefine)
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
    }
}

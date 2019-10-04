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
                model.FlowIndex = 1;
                model.IsComplete = false;

                FlowDAL.CreateNewEqRequest(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

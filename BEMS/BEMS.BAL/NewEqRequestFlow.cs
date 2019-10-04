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

        public void CreateNew(NewEqRequestModel model)
        {
            try
            {
                model.FlowIndex = 1;
                FlowDAL.CreateNewEqRequest(model);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

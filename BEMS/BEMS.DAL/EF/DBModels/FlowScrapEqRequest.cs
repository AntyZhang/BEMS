using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowScrapEqRequest : FlowBasic
    {
        public int Applyer { get; set; }

        public string Contact { get; set; }

        public int EquipmentID { get; set; }

        public string SerialNumber { get; set; }

    }
}

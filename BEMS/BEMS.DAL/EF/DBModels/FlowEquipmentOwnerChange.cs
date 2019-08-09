using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowEquipmentOwnerChange: FlowBasic
    {
        public int OriginalOwner { get; set; }
        public string OriginalOwnerName { get; set; }

        public int NewOwner { get; set; }
        public string NewOwnerName { get; set; }

    }
}

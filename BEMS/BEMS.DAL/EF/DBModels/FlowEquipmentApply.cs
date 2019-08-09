using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowEquipmentApply : FlowBasic
    {
        public int ApplyerID { get; set; }

        public string Contact { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string Address { get; set; }

        public int EquipmentType { get; set; }

        public int Amount { get; set; }

    }
}

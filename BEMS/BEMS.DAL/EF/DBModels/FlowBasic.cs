using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowBasic
    {
        public int ID { get; set; }
        public int CurrentApprover { get; set; }

        public DateTime CreateTime { get; set; }
        public int Creator { get; set; }
        public bool IsComplete { get; set; }
        public string Comment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    class FlowDefine
    {
        public int ID { get; set; }
        public int FlowType { get; set; }

        public string FlowStepDefine { get; set; }

        public DateTime CreatTime { get; set; }

        public int Creator { get; set; }
    }
}

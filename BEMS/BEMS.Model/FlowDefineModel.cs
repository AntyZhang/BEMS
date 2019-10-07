using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.Model
{
    public class FlowDefineModel
    {
        public int ID { get; set; }
        /// <summary>
        /// NEWEQ
        /// SCRAPEQ
        /// </summary>
        public string FlowType { get; set; }
        //{index:"",owner:""}
        public List<FlowDefineStep> Steps { get; set; }

        public DateTime CreatTime { get; set; }

        public int Creator { get; set; }
    }
    public class FlowDefineStep
    {
        public int Index { get; set; }

        public string Owner { get; set; }
    }
}

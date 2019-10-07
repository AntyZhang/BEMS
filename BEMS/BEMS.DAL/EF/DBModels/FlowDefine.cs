﻿using System;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowDefine
    {
        public int ID { get; set; }
        /// <summary>
        /// NEWEQ
        /// SCRAPEQ
        /// </summary>
        public string FlowType { get; set; }
        //{index:"",owner:""}
        public string FlowStepDefine { get; set; }

        public DateTime CreatTime { get; set; }

        public int Creator { get; set; }
    }
}

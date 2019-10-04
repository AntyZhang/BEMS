using System;
using System.ComponentModel.DataAnnotations;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowBasic
    {
        [Key]
        public string ID { get; set; }
        public int FlowIndex { get; set; }

        public string Memo { get; set; }

        public int Status { get; set; }
        public bool IsComplete { get; set; }
        public DateTime RequestTime { get; set; }
        public string Requester { get; set; }

    }
}

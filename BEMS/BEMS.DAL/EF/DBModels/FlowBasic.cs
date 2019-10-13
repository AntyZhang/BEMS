using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowBasic
    {
        [Key]
        public string ID { get; set; }
        //public int? CurrentFlowIndex { get; set; }
        //public string Assignee { get; set; }
        public string Memo { get; set; }

        //public int Status { get; set; }
        [Column(TypeName = "bit(1)")]
        public bool IsComplete { get; set; }
        public DateTime RequestTime { get; set; }
        public string Requester { get; set; }        
    }
}

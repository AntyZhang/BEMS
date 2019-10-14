using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowProgress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TicketID { get; set; }
        public string FlowType { get; set; }
        public int CurrentFlowStep { get; set; }
        public string Assignee { get; set; }
        public DateTime AssignTime { get; set; }
        public string Comments { get; set; }

        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}

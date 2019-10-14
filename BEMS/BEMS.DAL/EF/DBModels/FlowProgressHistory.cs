using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class FlowProgressHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string TicketID { get; set; }
        public string FlowType { get; set; }
        public int Step { get; set; }
        public string Comments { get; set; }
        public string ActionBy { get; set; }
        public string ActionTime { get; set; }
    }
}

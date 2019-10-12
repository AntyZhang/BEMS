using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.Model
{
    public class TicketSummaryModel
    {
        public string ID { get; set; }

        public String FlowType { get; set; }

        public string Requester { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsComplete { get; set; }
    }
}

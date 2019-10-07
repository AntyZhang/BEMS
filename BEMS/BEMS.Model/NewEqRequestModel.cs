using System;

namespace BEMS.Model
{
    public class NewEqRequestModel
    {

        public string Requester { get; set; }
        public DateTime RequestTime { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentNO { get; set; }
        public int Amount { get; set; }
        public string Memo { get; set; }
        public int CurrentFlowIndex { get; set; }
        public bool IsComplete { get; set; }
        public string Assignee { get; set; }
    }
}

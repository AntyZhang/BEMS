using System.ComponentModel.DataAnnotations.Schema;

namespace BEMS.DAL.EF.DBModels
{
    [Table("FlowNewEqRequest")]
    public class FlowNewEqRequest : FlowBasic
    {
        public string EquipmentType { get; set; }
        public string EquipmentNO { get; set; }
        public int Amount { get; set; }
    }
}

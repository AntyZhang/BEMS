using System.ComponentModel.DataAnnotations.Schema;

namespace BEMS.DAL.EF.DBModels
{
    [Table("FlowNewEqRequest")]
    public class FlowNewEqRequest : FlowBasic
    {
        //类型
        public string EType { get; set; }
        //型号
        public string EModel { get; set; }
        public int Amount { get; set; }

    }
}

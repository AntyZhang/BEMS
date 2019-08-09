using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class EquipmentUseage
    {
        [Key]
        public int ID { get; set; }

        public int EquipmentID { get; set; }

        public int OwnerID { get; set; }

        public DateTime UseStartDate { get; set; }

        public int OperatorID { get; set; }
    }
}

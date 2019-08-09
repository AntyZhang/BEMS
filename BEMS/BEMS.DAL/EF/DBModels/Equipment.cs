using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class Equipment
    {
        [Key]
        public int ID { get; set; }
        public string EType { get; set; }

        public string Vendor { get; set; }
        public string ENumber { get; set; }

        public string IP { get; set; }

        public string MAC { get; set; }

        public decimal LimitedUseage { get; set; }

        public bool IsINUse { get; set; }
    }
}

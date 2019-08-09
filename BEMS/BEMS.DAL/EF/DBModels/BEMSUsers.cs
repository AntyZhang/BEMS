using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class BEMSUsers
    {
        [Key]
        public int ID { get; set; }

        public string AccountName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public DateTime CreateTime { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}

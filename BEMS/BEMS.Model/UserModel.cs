using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.Model
{
    public class UserModel
    {
        public int? ID { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Memo { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyBy { get; set; }
        public bool State { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string AccountName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public string Memo { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public string CreateBy { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyBy { get; set; }
        [Required]
        [Column(TypeName = "bit(1)")]
        public bool State { get; set; }
    }
}

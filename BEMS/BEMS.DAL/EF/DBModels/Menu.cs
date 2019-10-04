using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEMS.DAL.EF.DBModels
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual Menu Parent { get; set; }
        public virtual ICollection<Menu> Children { get; set; }
    }
}

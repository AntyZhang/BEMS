using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEMS.Web.Models
{
    public class MenuModel
    {
        public string Title { get; set; }
        public bool Active { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public bool Selected { get; set; }

        public string Link { get; set; }
    }
}

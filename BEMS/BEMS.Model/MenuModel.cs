using System;
using System.Collections.Generic;
using System.Text;

namespace BEMS.Model
{
    public class MenuModel
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public bool Selected { get; set; }
        public List<MenuModel> Children { get; set; }
    }
}

using BEMS.DAL.EF;
using BEMS.DAL.EF.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BEMS.DAL
{
    public class MenuDAL
    {
        public static List<Menu> GetMenus()
        {
            using (var context = new BEMSContext())
            {
                var list = context.Menus.Where(a => a.ParentID == null).Include("Children");
                return list.ToList();
            }
        }
    }
}

using BEMS.DAL;
using BEMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using BEMS.DAL.EF.DBModels;

namespace BEMS.BAL
{
    public class MenuBAL
    {
        public static List<MenuModel> GetMenus()
        {
            try
            {
                var list = MenuDAL.GetMenus();
                var menuList = ConvertMenu(list);
                return menuList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<MenuModel> ConvertMenu(ICollection<Menu> menuList)
        {
            var list = new List<MenuModel>();
            if (menuList != null && menuList.Count != 0)
            {
                foreach (var menu in menuList)
                {
                    var item = new MenuModel()
                    {
                        Link = menu.Link,
                        Name = menu.Name,
                        Selected = false,
                        Children = ConvertMenu(menu.Children)
                    };
                    list.Add(item);
                }
            }
            return list;
        }
    }
}

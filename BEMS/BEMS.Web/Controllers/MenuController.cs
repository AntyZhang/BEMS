using BEMS.BAL;
using Microsoft.AspNetCore.Mvc;

namespace BEMS.Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult GetAllMenus()
        {
            var menuList = MenuBAL.GetMenus();

            return new JsonResult(menuList);
        }
    }
}

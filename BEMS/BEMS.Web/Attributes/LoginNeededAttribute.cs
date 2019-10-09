using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BEMS.Web.Attributes
{
    public class LoginNeededAttribute : ActionFilterAttribute
    {
        //
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = context.HttpContext.Session.GetString("CurrentUser");
            if (currentUser == null)
            {
                //context.HttpContext.Response.StatusCode = 401;
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}

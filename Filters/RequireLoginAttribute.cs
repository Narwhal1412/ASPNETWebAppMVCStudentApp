using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp.Filters
{
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool allowAnonymous = filterContext.ActionDescriptor
                .GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Length > 0
                || filterContext.ActionDescriptor.ControllerDescriptor
                .GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Length > 0;

            if (!allowAnonymous && filterContext.HttpContext.Session["Username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}
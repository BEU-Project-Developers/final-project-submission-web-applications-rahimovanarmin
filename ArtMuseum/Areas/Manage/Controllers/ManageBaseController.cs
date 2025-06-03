using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ManageBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.ActionDescriptor.RouteValues["action"];
            var controller = context.ActionDescriptor.RouteValues["controller"];

            if (string.Equals(controller, "Dashboard", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(action, "AccessDenied", StringComparison.OrdinalIgnoreCase))
            {
                base.OnActionExecuting(context);
                return;
            }

            var role = context.HttpContext.Session.GetString("Role");

            if (!string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", new { area = "" });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : ManageBaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

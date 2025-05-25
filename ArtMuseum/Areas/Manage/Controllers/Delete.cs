using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{[Area("Manage")]
    public class Delete : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

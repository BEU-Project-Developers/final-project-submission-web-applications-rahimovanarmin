using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

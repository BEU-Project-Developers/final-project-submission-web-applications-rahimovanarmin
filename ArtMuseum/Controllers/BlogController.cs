using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

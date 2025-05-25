using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class BlogSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

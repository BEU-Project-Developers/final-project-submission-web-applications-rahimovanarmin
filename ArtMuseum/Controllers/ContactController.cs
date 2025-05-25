using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

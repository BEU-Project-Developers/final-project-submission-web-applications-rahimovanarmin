using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

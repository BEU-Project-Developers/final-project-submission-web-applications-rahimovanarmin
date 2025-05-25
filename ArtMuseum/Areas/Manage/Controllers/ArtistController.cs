using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();

        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}

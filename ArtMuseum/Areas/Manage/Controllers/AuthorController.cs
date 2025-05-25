using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AuthorController : Controller

    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}

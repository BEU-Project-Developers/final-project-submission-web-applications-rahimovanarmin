using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ArtworkController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artwork model)
        {
            if (ModelState.IsValid)
            {
                // Veritabanına kayıt işlemi
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete()
        {
            return View();

        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}

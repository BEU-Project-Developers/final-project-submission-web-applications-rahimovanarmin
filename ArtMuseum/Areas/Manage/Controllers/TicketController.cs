using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Areas.Manage.Controllers
{
    public class TicketController : Controller
    {
        [Area("Manage")]

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

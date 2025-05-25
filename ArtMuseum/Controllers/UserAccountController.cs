using Microsoft.AspNetCore.Mvc;

namespace ArtMuseum.Controllers
{
    public class UserAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() { 
           return View();   
        }
        public IActionResult Login()
        {
            return View();
        }


    }
}

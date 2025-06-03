using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var artists = _context.Artist.Include(a => a.Artworks).ToList();
            return View(artists);
        }
     
    }
}

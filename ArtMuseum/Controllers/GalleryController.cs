using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var artworks = _context.Artwork.Include(a => a.Artist).ToList();
            return View(artworks);
        }

        public IActionResult Details(int id)
        {
            var artwork = _context.Artwork
      .Include(a => a.Artist)
        .Include(a => a.ArtworkArtStyles)
        .ThenInclude(aas => aas.ArtStyle)
      .FirstOrDefault(a => a.Id == id);

            if (artwork == null)
            {
                return NotFound();
            }


            return View(artwork);
        }

        public IActionResult Artist(int id)
        {
            var artist = _context.Artist
            .Include(a => a.Artworks)
            .FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();


            }
            return View(artist);
        }
    }
}

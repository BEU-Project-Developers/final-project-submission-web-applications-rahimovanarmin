using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ArtStylesController : ManageBaseController
	{
        private readonly AppDbContext _context;

        public ArtStylesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var styles = await _context.ArtStyle
                .Include(s => s.ArtworkArtStyles)
                    .ThenInclude(aas => aas.Artwork)
                .ToListAsync();

            return View(styles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtStyle model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.ArtStyle.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            // Later you'll fetch and return the model for editing
            return View();
        }

        public IActionResult Delete(int id)
        {
            // Later you'll fetch and return the model for confirmation
            return View();
        }
    }
}

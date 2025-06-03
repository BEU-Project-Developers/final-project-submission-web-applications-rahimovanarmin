using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           

            _context.ArtStyle.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var artStyle = await _context.ArtStyle
               
                .FirstOrDefaultAsync(a => a.Id == id);

            if (artStyle == null)
                return NotFound();

       

            return View(artStyle);
        }

        // POST: Manage/Artwork/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtStyle artStyle)
        {
            if (id != artStyle.Id)
                return BadRequest();



            try
            {
                // Update basic artwork fields
                _context.Update(artStyle);
                await _context.SaveChangesAsync();

             
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Artwork.Any(e => e.Id == artStyle.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Manage/Artwork/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var artwork = await _context.ArtStyle
          
                .FirstOrDefaultAsync(m => m.Id == id);

            if (artwork == null)
                return NotFound();

            return View(artwork);
        }

        // POST: Manage/Artwork/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artStyle = await _context.ArtStyle.FindAsync(id);
            if (artStyle != null)
            {
               

                _context.ArtStyle.Remove(artStyle);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}

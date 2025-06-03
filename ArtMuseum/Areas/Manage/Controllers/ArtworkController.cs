using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ArtworkController : ManageBaseController
	{
        private readonly AppDbContext _context;

        public ArtworkController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var artworks = await _context.Artwork
                .Include(a => a.Artist)
                .Include(a => a.ArtworkArtStyles)
                    .ThenInclude(aas => aas.ArtStyle)
                .ToListAsync();

            return View(artworks);
        }

        public IActionResult Create()
        {
            ViewData["Artists"] = new SelectList(_context.Artist, "Id", "Name");
            ViewData["ArtStyles"] = _context.ArtStyle.ToList();
            return View();
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Artwork artwork, List<int> SelectedArtStyleIds)
{

    // Save the artwork
    _context.Artwork.Add(artwork);
    await _context.SaveChangesAsync();

    // Save many-to-many relationships
    if (SelectedArtStyleIds != null && SelectedArtStyleIds.Any())
    {
        foreach (var styleId in SelectedArtStyleIds)
        {
            _context.ArtworkArtStyle.Add(new ArtworkArtStyle
            {
                ArtWorkId = artwork.Id,
                ArtStyleId = styleId
            });
        }
        await _context.SaveChangesAsync();
    }

    return RedirectToAction("Index");
}

        

        // GET: Manage/Artwork/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var artwork = await _context.Artwork
                .Include(a => a.ArtworkArtStyles)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (artwork == null)
                return NotFound();

            ViewData["Artists"] = new SelectList(_context.Artist, "Id", "Name", artwork.ArtistId);
            ViewData["ArtStyles"] = await _context.ArtStyle.ToListAsync();

            return View(artwork);
        }

        // POST: Manage/Artwork/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artwork artwork, List<int> SelectedArtStyleIds)
        {
            if (id != artwork.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewData["Artists"] = new SelectList(_context.Artist, "Id", "Name", artwork.ArtistId);
                ViewData["ArtStyles"] = await _context.ArtStyle.ToListAsync();
                return View(artwork);
            }

            try
            {
                // Update basic artwork fields
                _context.Update(artwork);
                await _context.SaveChangesAsync();

                // Update many-to-many relationship: ArtworkArtStyles
                var existingArtStyles = _context.ArtworkArtStyle.Where(aas => aas.ArtWorkId == id);
                _context.ArtworkArtStyle.RemoveRange(existingArtStyles);
                await _context.SaveChangesAsync();

                if (SelectedArtStyleIds != null)
                {
                    foreach (var styleId in SelectedArtStyleIds)
                    {
                        _context.ArtworkArtStyle.Add(new ArtworkArtStyle
                        {
                            ArtWorkId = id,
                            ArtStyleId = styleId
                        });
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Artwork.Any(e => e.Id == artwork.Id))
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

            var artwork = await _context.Artwork
                .Include(a => a.Artist)
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
            var artwork = await _context.Artwork.FindAsync(id);
            if (artwork != null)
            {
                // If you have related entities like ArtworkArtStyles, remove them first:
                var artworkArtStyles = _context.Set<ArtworkArtStyle>().Where(x => x.ArtWorkId == id);
                _context.Set<ArtworkArtStyle>().RemoveRange(artworkArtStyles);

                _context.Artwork.Remove(artwork);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
    
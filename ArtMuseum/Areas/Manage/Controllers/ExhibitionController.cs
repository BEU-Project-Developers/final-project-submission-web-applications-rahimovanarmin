using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ExhibitionController : ManageBaseController
	{
        private readonly AppDbContext _context;

        public ExhibitionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var exhibitions = await _context.Exhibition.ToListAsync();
            return View(exhibitions);
        }

        // GET: Exhibitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exhibitions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descriptions,Curator,Location,ImageUrl,TicketPrice,StartDate,EndDate")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibition);
        }


        // GET: Exhibitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descriptions,Curator,Location,ImageUrl,TicketPrice,StartDate,EndDate")] Exhibition exhibition)
        {
            if (id != exhibition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exhibition);
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibition.Any(e => e.Id == id);
        }


        // GET: Exhibitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var exhibition = await _context.Exhibition
                .FirstOrDefaultAsync(e => e.Id == id);
            if (exhibition == null) return NotFound();

            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null) return NotFound();

            _context.Exhibition.Remove(exhibition);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}

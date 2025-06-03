using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ArtistController : ManageBaseController
	{
        private readonly AppDbContext _context;

        public ArtistController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var artists = await _context.Artist.ToListAsync();
            return View(artists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the form errors.";
                return View(artist);
            }

            try
            {
                _context.Artist.Add(artist);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Artist created successfully!";
                return RedirectToAction(nameof(Index), new { area = "Manage" });
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Database error: {inner}";

                return View(artist);
            }
        }





        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
                return NotFound();

            return View(artist);
        }

        // POST: Manage/Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artist artist)
        {
            if (id != artist.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the form errors.";
                return View(artist);
            }

            try
            {
                _context.Update(artist);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Artist updated successfully!";
                return RedirectToAction(nameof(Index), new { area = "Manage" });
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Database error: {inner}";
                return View(artist);
            }
        }

        // GET: Manage/Artist/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null) return NotFound();

            return View(artist);
        }
    

        // POST: Manage/Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                TempData["ErrorMessage"] = "Artist not found.";
                return RedirectToAction(nameof(Index), new { area = "Manage" });
            }

            try
            {
                _context.Artist.Remove(artist);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Artist deleted successfully!";
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                TempData["ErrorMessage"] = $"Database error: {inner}";
            }

            return RedirectToAction(nameof(Index), new { area = "Manage" });
        }
    }
}

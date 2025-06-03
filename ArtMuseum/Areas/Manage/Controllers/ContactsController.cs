using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtMuseum.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ContactsController : ManageBaseController
	{
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manage/Contact
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contact.Include(c => c.User).ToListAsync();
            return View(contacts);
        }

        // GET: Manage/Contact/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.User, "Id", "FullName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", contact.UserId);
            return View(contact);
        }

        // GET: Manage/Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null) return NotFound();

            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", contact.UserId);
            return View(contact);
        }

        // POST: Manage/Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contact contact)
        {
            if (id != contact.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", contact.UserId);
            return View(contact);
        }

        // GET: Manage/Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contact
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        // POST: Manage/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}

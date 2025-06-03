using ArtMuseum.Areas.Manage.Controllers;
using ArtMuseum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArtMuseum.Controllers
{
    [Area("Manage")]
    public class UserController : ManageBaseController
	{
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }

            if (string.IsNullOrEmpty(user.Role))
            {
                ModelState.AddModelError("Role", "Role is required");
            }

            if (ModelState.IsValid)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, user.Password);
                user.Password = null;

                try
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred saving the user: " + ex.Message);
                }
            }

            return View(user);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return NotFound();

            user.Password = null;

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.User.FindAsync(id);
                    if (userFromDb == null) return NotFound();

                    userFromDb.Role = user.Role;

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        userFromDb.PasswordHash = _passwordHasher.HashPassword(userFromDb, user.Password);
                    }

                    _context.Update(userFromDb);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.Id == id);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

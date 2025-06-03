using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ArtMuseum.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public IActionResult Index()
        {
            var fullName = HttpContext.Session.GetString("FullName");
            if (!string.IsNullOrEmpty(fullName))
            {
                ViewBag.UserName = fullName;
            }

            return View();
        }

        // POST: Contact/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Contact contact)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "You must be logged in to send a message.";
                return RedirectToAction("Index");
            }

            contact.UserId = userId.Value;

            if (ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Your contact details have been sent successfully!";
                return RedirectToAction("Index");
            }

            // Keep form values on error
            ViewBag.Contact_PhoneNumber = contact.PhoneNumber;
            ViewBag.Contact_Address = contact.Address;

            TempData["ErrorMessage"] = "Please fix the errors below.";

            return View("Index", contact);
        }
    }
}

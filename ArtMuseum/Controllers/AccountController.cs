using ArtMuseum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AccountController(AppDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string Email, string Password)
    {
        var user = _context.User.FirstOrDefault(u => u.Email == Email);
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, Password) == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }

        HttpContext.Session.SetString("FullName", user.FullName);
        HttpContext.Session.SetString("Email", user.Email);
        HttpContext.Session.SetInt32("UserID", user.Id);
        HttpContext.Session.SetString("Role", user.Role);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
		if (!ModelState.IsValid)
		{
			return View(user);
		}

		if (_context.User.Any(u => u.Email == user.Email))
        {
            ModelState.AddModelError("Email", "This email is already registered.");
            return View(user);
        }

        user.PasswordHash = _passwordHasher.HashPassword(user, user.Password);
        user.Role = "User";

        _context.User.Add(user);
        _context.SaveChanges();

        HttpContext.Session.SetString("FullName", user.FullName);
        HttpContext.Session.SetString("Email", user.Email);
        HttpContext.Session.SetInt32("UserID", user.Id);
        HttpContext.Session.SetString("Role", user.Role);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
		return RedirectToAction("Index", "Home");
	}

    public IActionResult AccessDenied()
    {
        return View();
    }
}

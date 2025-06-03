using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtMuseum.Models;

namespace ArtMuseum.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var fullName = HttpContext.Session.GetString("FullName");
			if (!string.IsNullOrEmpty(fullName))
			{
				ViewBag.UserName = fullName;
			}

			var exhibitions = _context.Exhibition.ToList();
			ViewBag.Exhibitions = exhibitions;

			var blogs = _context.Blog.ToList();  // No Include anymore
			return View(blogs);
		}
	}
}

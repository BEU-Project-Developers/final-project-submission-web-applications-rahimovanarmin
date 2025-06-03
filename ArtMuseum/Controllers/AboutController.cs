using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtMuseum.Models;

namespace ArtMuseum.Controllers
{
	public class AboutController : Controller
	{
		private readonly AppDbContext _context;

		public AboutController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var blogs = _context.Blog.ToList();
			return View(blogs);
		}
	}
}

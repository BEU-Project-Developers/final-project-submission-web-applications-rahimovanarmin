using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtMuseum.Models;

namespace ArtMuseum.Controllers
{
	public class TicketController : Controller
	{
		private readonly AppDbContext _context;

		public TicketController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{

			var exhibitions = _context.Exhibition.ToList();
			ViewBag.Exhibitions = exhibitions;

			var blogs = _context.Blog.ToList();

			return View(blogs);
		}
	}
}

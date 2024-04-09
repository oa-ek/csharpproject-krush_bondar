using HealthyTreats.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HealthyTreats.Repositories.Comon;
using HealthyTreats.Core.Entities;
using Microsoft.CodeAnalysis;

namespace HealthyTreats.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Recipe, Guid> repository;
        public HomeController(ILogger<HomeController> logger,
            IRepository<Recipe, Guid> repository)
        {
			_logger = logger;
            this.repository = repository;
        }

		public IActionResult Index()
		{
			return View(repository.GetAllAsync());
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

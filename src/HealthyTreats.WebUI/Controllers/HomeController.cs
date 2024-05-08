using HealthyTreats.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HealthyTreats.Repositories.Comon;
using HealthyTreats.Core.Entities;
using Microsoft.CodeAnalysis;
using HealthyTreats.Repositories.Recipe;

namespace HealthyTreats.WebUI.Controllers
{
	public class HomeController : Controller
	{
        private readonly IRecipeRepository _recipeRepository;

        public HomeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return View(recipes);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }
    }
}

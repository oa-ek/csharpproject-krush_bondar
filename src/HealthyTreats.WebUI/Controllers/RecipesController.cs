using HealthyTreats.Core.Context;
using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTreats.WebUI.Controllers
{
    public class RecipesController : Controller
    {
        private readonly HealthyContext _context;

        public RecipesController(HealthyContext context)
        {
            _context = context;
        }

        // GET: /Recipes/Index
        public IActionResult Index()
        {
            var recipes = _context.Recipes.ToList();
            return View(recipes);
        }

        // GET: /Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                // Add code to save the new recipe to the database
                // After successful saving, you can redirect the user to another page
                return RedirectToAction("Index"); // For example, redirect to the recipe list page
            }
            return View(recipe);
        }

        // Other controller methods you may have
    }


}


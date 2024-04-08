using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTreats.WebUI.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
                // Додайте код для збереження нового рецепту в базу даних
                // Після успішного збереження можна перенаправити користувача на іншу сторінку
                return RedirectToAction("Index"); // Наприклад, перенаправлення на сторінку зі списком рецептів
            }
            return View(recipe);
        }

        // Інші методи контролера, які можливо у вас є
    }
    }


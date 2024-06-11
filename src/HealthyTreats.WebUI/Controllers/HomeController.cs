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
        private readonly IRecipeLikeRepository _recipeLikeRepository;

        public HomeController(IRecipeRepository recipeRepository, 
            IRecipeLikeRepository recipeLikeRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeLikeRepository = recipeLikeRepository;
        }

       /* public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return View(recipes);
        }*/

        public async Task<IActionResult> Details(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            var likes = await _recipeLikeRepository.GetLikesAsync(id);
            ViewBag.Likes = likes;
            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> LikeRecipe(Guid id)
        {
            await _recipeLikeRepository.AddLikeAsync(id);
            var likes = await _recipeLikeRepository.GetLikesAsync(id);
            return Json(new { success = true, liked = true, likes });
        }

        [HttpPost]
        public async Task<IActionResult> UnlikeRecipe(Guid id)
        {
            await _recipeLikeRepository.RemoveLikeAsync(id);
            var likes = await _recipeLikeRepository.GetLikesAsync(id);
            return Json(new { success = true, liked = false, likes });
        }


        //пошук 


        public async Task<IActionResult> Index(string searchTerm)
        {
            IEnumerable<Recipe> recipes;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                recipes = await _recipeRepository.SearchRecipesAsync(searchTerm);
            }
            else
            {
                recipes = await _recipeRepository.GetAllAsync();
            }
            return View(recipes);
        }
    }
}

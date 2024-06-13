
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
﻿using HealthyTreats.Core.Context;
using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HealthyTreats.Repositories.Recipe;
using HealthyTreats.Repositories.Users;
using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;
using System.Text.Json;
using HealthyTreats.WebUI.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace HealthyTreats.WebUI.Controllers
{

    public class RecipesController : Controller
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpClientFactory _clientFactory;


        public RecipesController(
            IRecipeRepository recipeRepository,
            IUsersRepository userRepository,
            IWebHostEnvironment webHostEnvironment,
            IHttpClientFactory clientFactory)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
            _clientFactory = clientFactory;
        }



        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Recipe> recipes;

            if (User.IsInRole("Admin"))
            {
                recipes = await _recipeRepository.GetAllAsyncWithDetails();
            }
            else if (Guid.TryParse(userId, out var authorId))
            {
                recipes = await _recipeRepository.GetByAuthorAsync(authorId);
            }
            else
            {
                return Unauthorized();
            }

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

        public async Task<IActionResult> Create()
        {

            ViewBag.Categories = new SelectList(await _recipeRepository.GetAllCategoriesAsync(), "Id", "Name");
            ViewBag.Ingredients = await _recipeRepository.GetAllIngredientsAsync();
            return View(new Recipe());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userId, out var authorId))
            {
                model.AuthorId = authorId;

                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        var fileExt = Path.GetExtension(model.ImageFile.FileName);
                        var filePath = Path.Combine("img", "recipes", $"{Guid.NewGuid()}{fileExt}");
                        string path = Path.Combine(wwwRootPath, filePath);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(fileStream);
                        }

                        model.ImagePath = filePath;
                    }

                    await _recipeRepository.CreateAsync(model);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Categories = new SelectList(await _recipeRepository.GetAllCategoriesAsync(), "Id", "TitleCategory");
                return View(model);
            }

            return Unauthorized();
        }

        [HttpPost("CreateWithDetails")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithDetails(Recipe model, List<Guid> SelectedCategories, List<Ingredient> Ingredients)
        {
            if (ModelState.IsValid)
            {
                // Збереження обраних категорій
                foreach (var categoryId in SelectedCategories)
                {
                    var category = await _recipeRepository.GetCategoryAsync(categoryId);
                    if (category != null)
                    {
                        model.Categories.Add(category);
                    }
                }

                // Збереження інгредієнтів
                foreach (var ingredient in Ingredients)
                {
                    model.Ingredients.Add(ingredient);
                }

                await _recipeRepository.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(await _recipeRepository.GetAllCategoriesAsync(), "Id", "Name");
            return View(model);
        }



        public async Task<IActionResult> Edit(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _recipeRepository.GetAllCategoriesAsync();
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Recipe model, List<Guid> selectedCategories, List<Ingredient> ingredients)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Оновлення категорій
                    model.Categories = new List<Category>();
                    foreach (var categoryId in selectedCategories)
                    {
                        var category = await _recipeRepository.GetCategoryAsync(categoryId);
                        if (category != null)
                        {
                            model.Categories.Add(category);
                        }
                    }

                    // Оновлення інгредієнтів
                    model.Ingredients = new List<Ingredient>();
                    foreach (var ingredient in ingredients)
                    {
                        model.Ingredients.Add(ingredient);
                    }

                    await _recipeRepository.UpdateAsync(model);
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _recipeRepository.GetAllCategoriesAsync();
            return View(model);
        }




        public async Task<IActionResult> Delete(Guid id)
        {
            var recipes = await _recipeRepository.GetAsync(id);
            return View(recipes);
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _recipeRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }


      



        // Метод з параметром Guid id
        public async Task<IActionResult> IngredientDetails(Guid id)
        {
            var ingredient = await _recipeRepository.GetIngredientAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient); // Передача модели в представление
        }


        //іра-парсення
        [HttpGet]
        public async Task<IActionResult> GetRecipeNutrition(string ingredientName, float quantity, string unit)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var apiKey = "b50564970bee5415b5d052bdc3a3e9bd";
                var formattedIngredient = $"{ingredientName} {quantity} {unit}";
                var encodedIngredient = Uri.EscapeDataString(formattedIngredient);
                var nutritionApiUrl = $"https://api.edamam.com/api/nutrition-data?app_id=6addb7a9&app_key={apiKey}&ingr={encodedIngredient}";

                var response = await client.GetAsync(nutritionApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var nutritionContent = await response.Content.ReadAsStringAsync();
                    return Content(nutritionContent, "application/json");
                }
                else
                {
                    return BadRequest("Failed to fetch nutrition data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




    }
}

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
using HealthyTreats.Repositories.User;
using HealthyTreats.Core.Entities;

namespace HealthyTreats.WebUI.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipesController(
            IRecipeRepository recipeRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _recipeRepository.GetAllCategoriesAsync(), "Id", "Name");
            return View(new Recipe());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = Path.Combine("/img/recipes/", $"{Guid.NewGuid()}{fileExt}");
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

            ViewBag.Categories = new SelectList(await _recipeRepository.GetAllCategoriesAsync(), "Id", "Name");
            return View(model);
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


        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


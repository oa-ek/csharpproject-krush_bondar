using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;

namespace HealthyTreats.WebUI.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IRepository<Ingredient, Guid> _ingredientRepository;

        public IngredientsController(IRepository<Ingredient, Guid> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return View(ingredients);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Ingredient());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Quantity, Unit")] Ingredient model)
        {
            if (ModelState.IsValid)
            {
                await _ingredientRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Ingredient model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ingredientRepository.UpdateAsync(model);
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _ingredientRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}

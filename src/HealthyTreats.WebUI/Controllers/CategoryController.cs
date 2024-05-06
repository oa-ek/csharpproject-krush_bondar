using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;

namespace HealthyTreats.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryController(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Category model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateAsync(model);
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

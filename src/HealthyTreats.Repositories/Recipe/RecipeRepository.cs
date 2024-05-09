using HealthyTreats.Core.Context;
using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Recipe
{
    public class RecipeRepository : Repository<HealthyTreats.Core.Entities.Recipe, Guid>, IRecipeRepository

    {
        public RecipeRepository(HealthyContext ctx) : base(ctx) { }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _ctx.Categorys.ToListAsync();
        }
        public async Task<Category> GetCategoryAsync(Guid categoryId)
        {
            return await _ctx.Categorys.FindAsync(categoryId);
        }
        public async Task<IEnumerable<HealthyTreats.Core.Entities.Recipe>> GetAllAsyncWithDetails()
        {
            return await _ctx.Recipes
                .Include(r => r.Categories) // Включити категорії рецептів
                .Include(r => r.Ingredients) // Включити інгредієнти рецептів
                .ToListAsync();
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ctx.Ingredients.ToListAsync();
        }

        public async Task<HealthyTreats.Core.Entities.Recipe> GetAsync(Guid id)
        {
            return await _ctx.Recipes
                .Include(r => r.Ingredients) // Завантаження інгредієнтів
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}

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


        //ааааааааааааааааааааааааааа
        public async Task<IEnumerable<HealthyTreats.Core.Entities.Recipe>> GetByAuthorAsync(Guid authorId)
        {
            return await _ctx.Recipes
                .Where(r => r.AuthorId == authorId)
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .ToListAsync();
        }
        //ааааааааааааааааааааааааааа


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
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Ingredient> GetIngredientAsync(Guid id)
		{
			return await _ctx.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
		}




        // Метод для перевірки, чи рецепт належить певному автору
        public async Task<bool> IsRecipeAuthorAsync(Guid recipeId, Guid authorId)
        {
            return await _ctx.Recipes.AnyAsync(r => r.Id == recipeId && r.AuthorId == authorId);
        }
    }
}

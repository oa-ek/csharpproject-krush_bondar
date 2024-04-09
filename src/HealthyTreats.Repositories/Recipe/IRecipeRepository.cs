using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Recipe
{

    public interface IRecipeRepository : IRepository<HealthyTreats.Core.Entities.Recipe, Guid>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);

    }

}

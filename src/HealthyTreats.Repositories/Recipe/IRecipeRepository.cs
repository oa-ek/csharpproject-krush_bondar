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
            //ппрп
        }
    
}

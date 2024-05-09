using HealthyTreats.Core.Entities;
using HealthyTreats.Repositories.Comon;
using HealthyTreats.Repositories.Recipe;
using HealthyTreats.Repositories.Users;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories
{
    public static class DependencyInjectionRepositories
    {
        
            public static void AddRepositories(this IServiceCollection services)
            {
                services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
                services.AddScoped<IRecipeRepository, RecipeRepository>();
                services.AddScoped<IUsersRepository, UsersRepository>();
                services.AddScoped<UserManager<User>>();
                services.AddScoped<RoleManager<IdentityRole<Guid>>>();
            }
        }
    }

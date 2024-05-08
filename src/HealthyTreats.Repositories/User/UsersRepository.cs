using HealthyTreats.Core.Entities;
using HealthyTreats.Core.Context;
using HealthyTreats.Repositories.Comon;
using HealthyTreats.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Users
{
    public class UsersRepository : Repository<HealthyTreats.Core.Entities.User, Guid>, IUsersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;


        public UsersRepository(HealthyContext ctx,
            UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager) : base(ctx) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<UserListItemModel>> GetAllWithRolesAsync()
        {
            var list = new List<UserListItemModel>();

            foreach (var user in await _ctx.Users.ToListAsync())
            {
                var userModel = new UserListItemModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Roles = new List<IdentityRole<Guid>>()
                };

                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    userModel.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
                }

                list.Add(userModel);
            }

            return list;
        }
    }
}

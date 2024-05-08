using HealthyTreats.Repositories.Comon;
using HealthyTreats.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Users
{
    public interface IUsersRepository : IRepository<HealthyTreats.Core.Entities.User, Guid>
    {
        public Task<IEnumerable<UserListItemModel>> GetAllWithRolesAsync();
    }
}

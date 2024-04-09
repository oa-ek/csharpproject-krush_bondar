using HealthyTreats.Repositories.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.User
{
    public interface IUserRepository : IRepository<HealthyTreats.Core.Entities.User, Guid>
    {
    }
}

using HealthyTreats.Core.Context;
using HealthyTreats.Repositories.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.User
{
    public class UserRepository : Repository<HealthyTreats.Core.Entities.User, Guid>, IUserRepository
    {
        public UserRepository(HealthyContext ctx) : base(ctx) { }
    }
}

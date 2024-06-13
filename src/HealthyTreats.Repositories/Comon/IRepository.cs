using HealthyTreats.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Comon
{
    public interface IRepository<TEntity, TKey>
         where TEntity : class, IEntity<TKey>
    {


        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task SaveAsync();
    }
}

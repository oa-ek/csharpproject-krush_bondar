using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Repositories.Recipe
{
    public interface IRecipeLikeRepository
    {
        Task<int> GetLikesAsync(Guid recipeId);
        Task AddLikeAsync(Guid recipeId);
        Task RemoveLikeAsync(Guid recipeId);
    }

    public class RecipeLikeRepository : IRecipeLikeRepository
    {
        private readonly Dictionary<Guid, int> _likes = new Dictionary<Guid, int>();

        public Task<int> GetLikesAsync(Guid recipeId)
        {
            _likes.TryGetValue(recipeId, out int likes);
            return Task.FromResult(likes);
        }

        public Task AddLikeAsync(Guid recipeId)
        {
            if (_likes.ContainsKey(recipeId))
            {
                _likes[recipeId]++;
            }
            else
            {
                _likes[recipeId] = 1;
            }
            return Task.CompletedTask;
        }

        public Task RemoveLikeAsync(Guid recipeId)
        {
            if (_likes.ContainsKey(recipeId) && _likes[recipeId] > 0)
            {
                _likes[recipeId]--;
            }
            return Task.CompletedTask;
        }
    }
    }

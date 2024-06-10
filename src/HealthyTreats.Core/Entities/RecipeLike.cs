using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
    public class RecipeLike
    {
        public Guid RecipeId { get; set; }
        public int LikeCount { get; set; }
    }
}

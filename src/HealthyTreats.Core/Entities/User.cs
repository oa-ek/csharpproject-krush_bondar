using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
	public class User : IdentityUser<Guid>, IEntity<Guid>
	{
		public string? FullName { get; set; }
		public virtual ICollection<Recipe> RecipesAuthor { get; set; } = new HashSet<Recipe>();
		public virtual ICollection<Recipe> RecipesClient { get; set; } = new HashSet<Recipe>();
	}

}

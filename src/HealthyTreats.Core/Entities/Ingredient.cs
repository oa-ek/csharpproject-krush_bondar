using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
	public class Ingredient : IEntity<Guid>
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Title { get; set; }
		public float Quantity { get; set; } 
		public string Unit { get; set; }
		public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
	}
}

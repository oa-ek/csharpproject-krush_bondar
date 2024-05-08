using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
	public class Category : IEntity<Guid>
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string TitleCategory { get; set; }



        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}

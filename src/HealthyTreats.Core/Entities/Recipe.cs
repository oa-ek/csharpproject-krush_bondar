using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HealthyTreats.Core.Entities
{
	public class Recipe : IEntity<Guid>
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string? Name { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public string? Instructons { get; set; } = string.Empty;
		public string? ImagePath { get; set; } = "/img/projects/no_photo.jpg";
		public User? Author { get; set; }

		[ForeignKey(nameof(Author))]
		 public Guid? AuthorId { get; set; }
		
		[NotMapped]
		public IFormFile? ImageFile { get; set; }
		public  virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
		public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
	}
}

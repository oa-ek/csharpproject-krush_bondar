using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyTreats.Core.Context
{
    public class HealthyContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public HealthyContext(DbContextOptions<HealthyContext> options)
          : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Author)                // Кожен рецепт має одного автора
                .WithMany(u => u.RecipesAuthor)             // Кожен користувач може мати багато рецептів
                .HasForeignKey(r => r.AuthorId);

            modelBuilder.Entity<Recipe>().HasMany(g => g.Categories).WithMany(g => g.Recipes);
            modelBuilder.Entity<Recipe>().HasMany(g => g.Ingredients).WithMany(g => g.Recipes);

        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Category> Categorys => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
         public DbSet<NutritionalInfo> NutritionalInfos => Set<NutritionalInfo>();
    }
}
		



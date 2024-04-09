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
              .HasOne(r => r.Author)
              .WithMany(u => u.RecipesAuthor)
              .HasForeignKey(r => r.AuthorId)
              .IsRequired(false);

            modelBuilder.Entity<Recipe>()
                         .HasMany(r => r.Categories)
                         .WithMany(c => c.Recipes)
                         .UsingEntity(j => j.ToTable("RecipeCategory"));

            modelBuilder.Entity<Recipe>()
              .HasMany(r => r.Ingredients)
              .WithMany(i => i.Recipes);

            modelBuilder.Seed();
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Category> Categorys => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    }
}
		



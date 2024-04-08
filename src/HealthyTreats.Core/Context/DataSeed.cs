using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Context
{
	public static class DataSeed
	{
		public static void Seed(this ModelBuilder builder)
		{
			var userId = _seedUsers(builder);
			var categoryId = _seedCategories(builder);
			var recipeId = _seedRecipes(builder, userId, categoryId);
		}

		private static Guid _seedUsers(ModelBuilder builder)
		{
			var userId = Guid.NewGuid();

			var user = new User
			{
				Id = userId,
				UserName = "user1@example.com",
				EmailConfirmed = true,
				NormalizedUserName = "USER1@EXAMPLE.COM",
				Email = "user1@example.com",
				FullName = "John Doe"
			};

			var user2 = new User
			{
				Id = Guid.NewGuid(),
				UserName = "user2@example.com",
				EmailConfirmed = true,
				NormalizedUserName = "USER2@EXAMPLE.COM",
				Email = "user2@example.com",
				FullName = "Jane Smith"
			};

			PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
			user.PasswordHash = passwordHasher.HashPassword(user, "Password123");
			user2.PasswordHash = passwordHasher.HashPassword(user2, "Password456");

			builder.Entity<User>()
				.HasData(user, user2);

			return userId;
		}

		private static Guid _seedCategories(ModelBuilder builder)
		{
			var categoryId = Guid.NewGuid();

			var category = new Category
			{
				Id = categoryId,
				TitleCategory = "Vegan"
			};

			var category2 = new Category
			{
				Id = Guid.NewGuid(),
				TitleCategory = "Vegatarian"
			};

			builder.Entity<Category>()
				.HasData(category, category2);

			return categoryId;
		}

		private static Guid _seedRecipes(ModelBuilder builder, Guid userId, Guid categoryId)
		{
			var recipeId = Guid.NewGuid();

			var recipe = new Recipe
			{
				Id = recipeId,
				Name = "Chocolate Cake",
				Description = "Delicious chocolate cake recipe",
				Instructons = "1. Preheat oven to 350°F (180°C). 2. Mix ingredients. 3. Bake for 30 minutes.",
				AuthorId = userId
			};

			// Add the recipe to the context
			builder.Entity<Recipe>().HasData(recipe);

			// EF Core automatically adds records to the intermediate table RecipeCategory

			// Add code to add records to the intermediate table for many-to-many relationship with ingredients

			// For each ingredient you want to add to the recipe, create an IngredientRecipe object and add it to the context
			// builder.Entity<Recipe>().HasData(recipe);

			// Add other records for other ingredients that need to be added to the recipe

			return recipeId;
		}


	}
}


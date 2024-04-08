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
			var ingredientId = _seedIngredients(builder);
			var recipeId = _seedRecipes(builder, userId, categoryId, ingredientId);
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
		private static Guid _seedIngredients(ModelBuilder builder)
		{
			var ingredientsId = Guid.NewGuid();

			var ingredients = new Ingredient
			{
				Id = ingredientsId,
				Title = "Vegan1",
			 Quantity = 5,
		Unit = "Vegan4"

			};

			var ingredients2 = new Ingredient
			{
				Id = Guid.NewGuid(),
				Title = "Vegan3",
				Quantity = 5,
				Unit = "Vegan6"

			};

			builder.Entity<Ingredient>()
				.HasData(ingredients, ingredients2);

			return ingredientsId;
		}
		private static Guid _seedRecipes(ModelBuilder builder, Guid userId, Guid categoryId, Guid ingredientsId)
		{
			var recipeId = Guid.NewGuid();

			var recipe = new Recipe
			{
				Id = recipeId,
				Name = "Chocolate Cake",
				Description = "Delicious chocolate cake recipe",
				Instructons = "1. Preheat oven to 350°F (180°C). 2. Mix ingredients. 3. Bake for 30 minutes.",
				AuthorId = userId,
				CategoryId = categoryId,// Додаємо ідентифікатор категорії без проміжного класу
				IngredientId = ingredientsId // Додаємо ідентифікатор категорії без проміжного класу
			};

			// Додайте рецепт до контексту
			builder.Entity<Recipe>().HasData(recipe);

			return recipeId;
		}


	}
}


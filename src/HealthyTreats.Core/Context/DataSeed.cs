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
                    TitleCategory = "Dairy free"
                };
                var category3 = new Category
                {
                    Id = Guid.NewGuid(),
                    TitleCategory = "Gluten free"
                };
                var category4 = new Category
                {
                    Id = Guid.NewGuid(),
                    TitleCategory = "Vegatarian"
                };
                builder.Entity<Category>()
                  .HasData(category, category2, category3, category4);

                return categoryId;
            }
            private static Guid _seedIngredients(ModelBuilder builder)
            {
                var ingredientsId = Guid.NewGuid();

                var ingredients = new Ingredient
                {
                    Id = ingredientsId,
                    Title = "almond flour",
                    Quantity = 1,
                    Unit = "cup"

                };

                var ingredients2 = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Title = "unsweetened cocoa powder",
                    Quantity = 0.5f,
                    Unit = "cup"

                };
                var ingredients3 = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Title = "stevia ",
                    Quantity = 0.5f,
                    Unit = "cup"

                };
                var ingredients4 = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Title = "baking powder",
                    Quantity = 0.5f,
                    Unit = "teaspoon"

                };
                var ingredients5 = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Title = "salt",
                    Quantity = 0.2f,
                    Unit = "teaspoon"

                };
                var ingredients6 = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Title = "eggs 3 pieces",
                    Quantity = 3,
                    Unit = "pieces"
};
            var ingredients7 = new Ingredient
            {
                Id = Guid.NewGuid(),
                Title = "almond milk ",
                Quantity = 0.5f,
                Unit = "cup"

            };

            builder.Entity<Ingredient>()
              .HasData(ingredients, ingredients2, ingredients3, ingredients4, ingredients5, ingredients6 , ingredients7);

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
                ImagePath = "/img/recipes/no_photo.jpg"
            };

            // Добавляем категорию к рецепту
            var category = new Category { Id = categoryId };
            recipe.Categories.Add(category);

            // Добавляем ингредиент к рецепту
            var ingredient = new Ingredient { Id = ingredientsId };
            recipe.Ingredients.Add(ingredient);

            // Добавляем рецепт в контекст
            builder.Entity<Recipe>().HasData(recipe);

            return recipeId;
        }



    }



}
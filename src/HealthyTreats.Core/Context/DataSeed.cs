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

            var (adminRoleId, userRoleId) = _seedRoles(builder);

            var adminId = _seedAdmin(builder, adminRoleId);
            var userId = _seedUsers(builder, userRoleId);
        }

        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = adminRoleId,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = adminRoleId.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = userRoleId,
                       Name = "User",
                       NormalizedName = "USER",
                       ConcurrencyStamp = userRoleId.ToString()
                   }
               );

            return (adminRoleId, userRoleId);
        }

        private static Guid _seedAdmin(ModelBuilder builder, Guid adminRoleId)
        {
            var adminId = Guid.NewGuid();

            var admin = new User
            {
                Id = adminId,
                UserName = "admin@example.com",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN@EXAMPLE.COM".ToUpper(),
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Admin"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123");

            builder.Entity<User>()
                .HasData(admin);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = adminRoleId,
                      UserId = adminId
                  }
              );

            return adminId;
        }

        private static Guid _seedUsers(ModelBuilder builder, Guid userRoleId)
        {
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                UserName = "user@example.com",
                EmailConfirmed = true,
                NormalizedUserName = "USER@EXAMPLE.COM".ToUpper(),
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "User"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "User123");

            builder.Entity<User>()
                .HasData(user);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = userRoleId,
                      UserId = userId
                  }
              );

            return userId;
        }
    

    //для даних
    private static Guid _seedCategories(ModelBuilder builder)
        {
            var categoryId = Guid.NewGuid();

            var category = new Category

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


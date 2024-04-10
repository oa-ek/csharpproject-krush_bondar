﻿// <auto-generated />
using System;
using HealthyTreats.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthyTreats.Core.Migrations
{
    [DbContext(typeof(HealthyContext))]
    [Migration("20240409230103_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryRecipe", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("RecipeCategory", (string)null);
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TitleCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c614a72-d5a3-43e7-ae39-53d817651d1f"),
                            TitleCategory = "Vegan"
                        },
                        new
                        {
                            Id = new Guid("d16e8c69-f0a6-4b25-b5db-7338620ab917"),
                            TitleCategory = "Dairy free"
                        },
                        new
                        {
                            Id = new Guid("f543173d-499b-4119-8efc-2674a04d2888"),
                            TitleCategory = "Gluten free"
                        },
                        new
                        {
                            Id = new Guid("993a5d2f-e7a7-4969-bf83-a5841c7b6788"),
                            TitleCategory = "Vegatarian"
                        });
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bd2591b-23bd-4177-8002-930ae658d382"),
                            Quantity = 1f,
                            Title = "almond flour",
                            Unit = "cup"
                        },
                        new
                        {
                            Id = new Guid("94214e5b-633b-49f5-9dfc-fe12413bd7c9"),
                            Quantity = 0.5f,
                            Title = "unsweetened cocoa powder",
                            Unit = "cup"
                        },
                        new
                        {
                            Id = new Guid("2fce79db-de5e-49d1-a4b4-770f94360f5a"),
                            Quantity = 0.5f,
                            Title = "stevia ",
                            Unit = "cup"
                        },
                        new
                        {
                            Id = new Guid("5eca529b-1b29-4133-a8e3-f052c4793e9a"),
                            Quantity = 0.5f,
                            Title = "baking powder",
                            Unit = "teaspoon"
                        },
                        new
                        {
                            Id = new Guid("d6cebc56-7f39-41f8-a48d-977ced353a29"),
                            Quantity = 0.2f,
                            Title = "salt",
                            Unit = "teaspoon"
                        },
                        new
                        {
                            Id = new Guid("b6c0107e-5dc2-495d-8c7d-a0851e585837"),
                            Quantity = 3f,
                            Title = "eggs 3 pieces",
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = new Guid("b72cb016-387b-4b60-9dfe-c8ce5a873600"),
                            Quantity = 0.5f,
                            Title = "almond milk ",
                            Unit = "cup"
                        });
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Instructons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ClientId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec37e7f9-77b8-47b0-81f8-9011ad5772ea"),
                            AuthorId = new Guid("d837f32a-84c5-468d-bd74-0d810395acdb"),
                            CategoryId = new Guid("9c614a72-d5a3-43e7-ae39-53d817651d1f"),
                            Description = "Delicious chocolate cake recipe",
                            ImagePath = "/img/recipes/no_photo.jpg",
                            IngredientId = new Guid("8bd2591b-23bd-4177-8002-930ae658d382"),
                            Instructons = "1. Preheat oven to 350°F (180°C). 2. Mix ingredients. 3. Bake for 30 minutes.",
                            Name = "Chocolate Cake"
                        });
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d837f32a-84c5-468d-bd74-0d810395acdb"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1013a8eb-ecd8-4269-845e-25cfb459a2fc",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            FullName = "John Doe",
                            LockoutEnabled = false,
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEARl3rilr+9HONuvw8tIdh+7u751ZgWs4X5fSB/G/6ZKQdqbL5HdMi/cJ7zsD7lhrg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {
                            Id = new Guid("2e303955-5204-43e2-9157-dd431245b13c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aee37349-f98d-4d2f-a17e-fa42ebe3cd1d",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            FullName = "Jane Smith",
                            LockoutEnabled = false,
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEI+4a3zThuOYljFfkMFuv0VcATley3uo4IVMLu94Nl/Y1r3ZNt1IiwQWPJpVp0h3Zw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        });
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.Property<Guid>("IngredientsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngredientsId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("IngredientRecipe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CategoryRecipe", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTreats.Core.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.Recipe", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.User", "Author")
                        .WithMany("RecipesAuthor")
                        .HasForeignKey("AuthorId");

                    b.HasOne("HealthyTreats.Core.Entities.User", "Client")
                        .WithMany("RecipesClient")
                        .HasForeignKey("ClientId");

                    b.Navigation("Author");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTreats.Core.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTreats.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("HealthyTreats.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthyTreats.Core.Entities.User", b =>
                {
                    b.Navigation("RecipesAuthor");

                    b.Navigation("RecipesClient");
                });
#pragma warning restore 612, 618
        }
    }
}
using HealthyTreats.Core.Context;
using HealthyTreats.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthyTreats.Repositories;
using HealthyTreats.Repositories.Recipe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HealthyConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HealthyContext>(options =>
  options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(
  options => {
      options.SignIn.RequireConfirmedAccount = false;
      options.Password.RequireDigit = false;
      options.Password.RequireLowercase = false;
      options.Password.RequireUppercase = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequiredLength = 5;
  }).AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<HealthyContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRepositories();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IRecipeLikeRepository, RecipeLikeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "IngredientDetails",
    pattern: "Recipes/IngredientDetails/{id}",
    defaults: new { controller = "Recipes", action = "IngredientDetails" }
);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
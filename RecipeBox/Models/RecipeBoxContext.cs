using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models;

public class RecipeBoxContext : DbContext
{
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Step> Steps { get; set; }
  public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
  public DbSet<Meal> Meals { get; set; }
  public DbSet<MealRecipe> MealRecipes { get; set;}
  public DbSet<Comment> Comments { get; set; }
  public RecipeBoxContext(DbContextOptions options) : base(options) { }
}
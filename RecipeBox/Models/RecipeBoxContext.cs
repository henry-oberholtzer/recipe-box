using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models;

public class RecipeBoxContext : DbContext
{
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Type> Types { get; set; }
  public DbSet<RecipeType> RecipeTypes { get; set;}

  public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
  public RecipeBoxContext(DbContextOptions options) : base(options) { }
}


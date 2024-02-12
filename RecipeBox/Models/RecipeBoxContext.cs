using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models;

public class RecipeBoxContext : DbContext
{
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Type> Types { get; set; }
  public DbSet<RecipeType> RecipeTypes { get; set;}
  public DbSet<Step> Steps  { get; set; }
  public DbSet<RecipeStep> RecipeSteps { get; set; }
  public RecipeBoxContext(DbContextOptions options) : base(options) { }
}


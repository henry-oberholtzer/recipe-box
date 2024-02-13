using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models;

public class RecipeBoxContext : DbContext
{
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Step> Steps { get; set; }
  public DbSet<RecipeStep> RecipeSteps { get; set; }
  public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
  public DbSet<Meal> Meals { get; set; }
  public DbSet<MealRecipe> MealRecipes { get; set;}
  public RecipeBoxContext(DbContextOptions options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<RecipeStep>()
        .HasKey(rs => new { rs.RecipeId, rs.StepId });

    modelBuilder.Entity<RecipeStep>()
        .HasOne(RecipeSteps => RecipeSteps.Recipe)
        .WithMany(r => r.RecipeSteps)
        .HasForeignKey(rs => rs.RecipeId);

    modelBuilder.Entity<RecipeStep>()
        .HasOne(rs => rs.Step)
        .WithMany(s => s.RecipeSteps)
        .HasForeignKey(rs => rs.StepId);
  }
}


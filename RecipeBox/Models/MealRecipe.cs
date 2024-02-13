
namespace RecipeBox.Models;

public class MealRecipe
{
  public int MealRecipeId { get; set; }
  public int MealId { get; set; }
  public Meal Meal { get; set; }
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }
}

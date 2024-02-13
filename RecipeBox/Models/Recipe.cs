using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models;

public class Recipe
{
  public int RecipeId { get; set; }

  [Required]
  public string Title { get; set; }

  [Required]
  public string Description { get; set; }

  [Display(Name = "Photo URL")]
  public string PhotoUrl { get; set; }
  [Display(Name = "Recipe Date")]

  public DateOnly RecipeDate { get; set; }
  public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

  public List<RecipeStep> RecipeSteps { get; }


  public List<IngredientRecipe> IngredientRecipes { get; set; }

  public List<MealRecipe> MealRecipes { get; }


}

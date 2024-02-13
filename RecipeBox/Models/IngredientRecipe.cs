using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models;

public class IngredientRecipe
{
  public int IngredientRecipeId { get; set; }

  [Display(Name = "Ingredient")]
  public int IngredientId { get; set; }
  public int RecipeId { get; set; }

  public int Amount { get; set; }

  public int Unit { get; set; }
  public Ingredient Ingredient { get; set; }
  public Recipe Recipe { get; set; }

}

public enum Units
{
  Teaspoon,
  Tablespoon,
  Cup,
  Ounce,
  FluidOunce,
  Pound,

  Milligrams,
  Grams,
  Kilograms,

  Slice,
  Loaf,
  x
}

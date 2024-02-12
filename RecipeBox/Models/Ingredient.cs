using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models;

public class Ingredient
{
  public int IngredientId { get; set; }

  [Required]
  [Display(Name = "Ingredient Name")]
  [StringLength(255, ErrorMessage = "The ingredient may not be longer than 255 characters")]
  public string Name { get; set; }
  public List<IngredientRecipe> IngredientRecipes { get; set; }
}

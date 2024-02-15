using RecipeBox.Models;

namespace RecipeBox.ViewModels;

public class IndexViewModel
{
  public List<Recipe> AllRecipes { get; set; }
#nullable enable
  public List<Recipe>? UserRecipes { get; set; } = null;
#nullable disable
}
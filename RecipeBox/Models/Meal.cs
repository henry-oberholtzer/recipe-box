using System;
using System.Collections.Generic;

namespace RecipeBox.Models;

public class Meal
{
  public int MealId { get; set; }
  public string Name { get; set; }
  public List<MealRecipe> MealRecipes { get; }
}
using System;
using System.Collections.Generic;

namespace RecipeBox.Models;

public class Recipe
{
  public int RecipeId { get; set; }
  public string Description { get; set; }
  public string Instruction { get; set; }
  public int Rating { get; set; }
  public string PhotoUrl { get; set; }
  public DateOnly PublishDate { get; set; } = DateOnly.Now;
  public int IngredientId { get; set; }
  public Ingredient Ingredient { get; set; }
  public List<RecipeType> JoinEntities { get; }
}

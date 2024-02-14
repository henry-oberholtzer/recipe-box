namespace RecipeBox.Models;

public class RecipeTag
{
  int RecipeTagId { get; set; }
  int RecipeId { get; set; }

  int TagId { get; set; }

  Tag Tag { get; }

  Recipe Recipe { get; }

}

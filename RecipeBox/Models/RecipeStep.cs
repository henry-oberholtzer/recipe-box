namespace RecipeBox.Models;

public class RecipeStep
{
  public int RecipeStepId { get; set; }
  public int StepId { get; set; }
  public Step Step { get; set; }
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }
}
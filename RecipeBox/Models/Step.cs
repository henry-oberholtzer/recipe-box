namespace RecipeBox.Models;

public class Step
{
  public int StepId { get; set; }

  public int RecipeId { get; set; }

  public Recipe Recipe { get; set; }
  public int StepIndex { get; set;}
  public string Description { get; set; }

}

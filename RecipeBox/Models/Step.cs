using System.Collections.Generic;

namespace RecipeBox.Models;

public class Step
{
  public int StepId { get; set; }
  public string StepIndex { get; set;}
  public Recipe Recipe { get; set;}
  public List<RecipeStep> RecipeSteps { get; }

}

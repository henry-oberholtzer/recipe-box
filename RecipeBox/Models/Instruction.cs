using System.Collections.Generic;

namespace RecipeBox.Models;

public class Instruction
{
  public int InstructionId { get; set; }
  public string StepIndex { get; set;}
  public string Description { get; set;}
  public List<InstructionRecipe> JoinEntities { get; }

}
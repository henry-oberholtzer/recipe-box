namespace RecipeBox.Models;

public class InstructionRecipe
{
  public int InstructionRecipeId { get; set; }
  public int InstructionId { get; set; }
  public Instruction Instruction { get; set; }
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }
}
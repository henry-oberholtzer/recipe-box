using System.ComponentModel.DataAnnotations;

namespace RecipeBox.ViewModels;

public class TagViewModel
{
  [Required]
  [MaxLength(512)]
  public string Tags { get; set; }

  [Range(0, int.MaxValue)]
  public int RecipeId { get; set; }
}

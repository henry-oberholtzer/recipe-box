using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models;

public class Comment
{
  public int CommentId { get; set; }
  [Required]
  [Display(Name = "Comment")]

  public string Body { get; set; }
  [Required]

  public int Rating { get; set; }
  public DateOnly DatePosted { get; set; } = DateOnly.FromDateTime(DateTime.Now);
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }

}
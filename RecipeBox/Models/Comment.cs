using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models;

public class Comment
{
  public int CommentId { get; set; }
  public string Body { get; set; }
  public int Rating { get; set; }
  public DateOnly DatePosted { get; set; }
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }

}
using Microsoft.AspNetCore.Identity;

namespace RecipeBox.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string ImageURL { get; set; }
    public DateOnly Birthday { get; set; }

    public DateOnly DateAdded { get; set; }
  }
}
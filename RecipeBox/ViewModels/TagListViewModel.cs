using RecipeBox.Models;

namespace RecipeBox.ViewModels;

public class TagListViewModel
{
  private  List<RecipeTag> _recipeTags;
  public List<RecipeTag> RecipeTags
  {
    set => _recipeTags = value;
  }

  public List<Tag> Tags() {
    List<Tag> tagList = new(){};
    this._recipeTags.ForEach(rt => tagList.Add(rt.Tag));
    return tagList;
  }

  public int RecipeId { get; set; }
}

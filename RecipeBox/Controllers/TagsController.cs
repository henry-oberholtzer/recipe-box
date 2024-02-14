using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;
using RecipeBox.ViewModels;

namespace RecipeBox.Controllers;

public class TagsController : Controller
{
      private readonly RecipeBoxContext _db;
    public TagsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Tags.Include(t => t.RecipeTags).ToList());
    }

    [HttpPost]
    public ActionResult Create(TagViewModel model)
    {
      if(!string.IsNullOrWhiteSpace(model.Tags))
      {
        string[] allTagStrings = model.Tags.Split(",");
        List<int> tagIds = new(){};
        foreach (string tagString in allTagStrings)
        {
          string tagClean = $"#{tagString.ToLower().Trim()}";
          if(!_db.Tags.Any(t => t.Name == tagClean))
          {
            Tag tag = new(){
              Name = tagClean
            };
            _db.Tags.Add(tag);
            _db.SaveChanges();
            tagIds.Add(tag.TagId);
          };
        }
        foreach (int tagId in tagIds)
        {
          RecipeTag recipeTag = new()
          {
            RecipeId = model.RecipeId,
            TagId = tagId
          };
          _db.Add(recipeTag);
        }
        _db.SaveChanges();
      }
      return RedirectToAction("Details", "Recipe", new { id = model.RecipeId });
    }
}

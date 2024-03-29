using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Metadata.Internal; //for search bar

namespace RecipeBox.Controllers
{
  public class CommentsController : Controller
  {
    private readonly RecipeBoxContext _db;
    public CommentsController(RecipeBoxContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Comment> model = _db.Comments.Include(comment => comment.Recipe).ToList();
      return View(model);
    }

    public static Dictionary<string, object>
    CommentFormModel(Comment comment, Recipe recipe, string action)
    {
      return new Dictionary<string, object> {
        {"Comment", comment},
        {"Recipe", recipe},
        {"Action", action}
      };
    }

    [HttpGet("/Comments/Create/{recipeId}")]
    public ActionResult Create(int recipeId)
    {
     Recipe recipe = _db.Recipes.Include(r => r.Comments).FirstOrDefault(r => r.RecipeId == recipeId);
      return View(CommentFormModel(new Comment(), recipe, "Create"));
    }

    [HttpPost]
    public ActionResult Create(Comment comment)
    {
      if (!ModelState.IsValid)
      {
        Recipe recipe = _db.Recipes.Include(r => r.Comments).FirstOrDefault(r => r.RecipeId == comment.RecipeId);
        return View(CommentFormModel(comment, recipe, "Create"));
      }
      _db.Comments.Add(comment);
      _db.SaveChanges();
      return RedirectToAction("Create", new { recipeId = comment.RecipeId});
    }

  }
}
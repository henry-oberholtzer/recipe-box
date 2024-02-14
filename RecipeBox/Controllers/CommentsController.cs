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
      // List<Comment> model = _db.Comments.Include(comment => comment.Recipe).ToList();
      return View(_db.Comments.ToList());
    }

    public static Dictionary<string, object>
    CommentFormModel(Comment comment, Recipe recipe)
    {
      return new Dictionary<string, object> {
        {"Comment", comment},
        {"Recipe", recipe}
      };
    }

    [HttpGet("/Comments/Create/{recipeId}")]
    public ActionResult Create(int recipeId)
    {
     Recipe recipe = _db.Recipes.Include(r => r.Comments).FirstOrDefault(r => r.RecipeId == recipeId);
      return View(CommentFormModel(new Comment(), recipe));
    }

    [HttpPost]
    public ActionResult Create(Comment comment)
    {
     Recipe recipe = _db.Recipes.Include(r => r.Comments).FirstOrDefault(r => r.RecipeId == comment.RecipeId);
      if (!ModelState.IsValid)
      {
        return View(CommentFormModel(comment, recipe));
      }
      _db.Comments.Add(comment);
      _db.SaveChanges();
      return RedirectToAction("Create", new { recipeId = recipe.RecipeId});
    }
    // public ActionResult Edit(Comment comment)
    // {
    //   // Comment thisComment = _db.Comments.FirstOrDefault(comment => comment.CommentId == id);
    //   // return View(thisComment);
    // }

  }
}
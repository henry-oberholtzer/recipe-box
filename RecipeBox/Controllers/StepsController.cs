using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks.Dataflow;
using System;

namespace RecipeBox.Controllers
{
  public class StepsController : Controller
  {
    private readonly RecipeBoxContext _db;
    public StepsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Steps.ToList());
    }

    public static Dictionary<string, object> StepFormModel(Step step, Recipe recipe)
    {
      return new Dictionary<string, object> {
        {"Step", step},
        {"Recipe", recipe}
      };
    }

    [HttpGet("/Steps/Create/{recipeId}")]
    public ActionResult Create(int recipeId)
    {
      Recipe recipe = _db.Recipes.Include(r => r.Steps).FirstOrDefault(r => r.RecipeId == recipeId);
      return View(StepFormModel(new Step(), recipe));
    }

    [HttpPost]
    public ActionResult Create(Step step)
    {
      Recipe recipe = _db.Recipes.Include(r => r.Steps).FirstOrDefault(r => r.RecipeId == step.RecipeId);
      if (!ModelState.IsValid)
      {
        return View(StepFormModel(step, recipe));
      }
      _db.Steps.Add(step);
      _db.SaveChanges();
      return RedirectToAction("Create", new { recipeId = recipe.RecipeId});

    }
  }
}

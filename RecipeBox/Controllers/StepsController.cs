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

    public ActionResult Details(int id)
    {
      Step thisStep = _db.Steps
      .Include(step => step.JoinEntities)
      .ThenInclude(join => join.Recipe)
      .FirstOrDefault(step => step.StepId == id);
      return View(thisStep);
    }

    public ActionResult AddRecipe(int id)
    {
      Step thisStep = _db.Steps.FirstOrDefault(steps => steps.StepId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Title");
      return View(thisStep);
    }
    [HttpPost]
    public ActionResult AddRecipe(Step step, int recipeId)
    {
#nullable enable
      RecipeStep? joinEntity = _db.RecipeSteps.FirstOrDefault(join => (join.RecipeId == recipeId && join.StepId == step.StepId));
#nullable disable
      if (joinEntity == null && recipeId != 0)
      {
        _db.RecipeSteps.Add(new RecipeStep() { RecipeId = recipeId, StepId = step.StepId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = step.StepId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      RecipeStep joinEntry = _db.RecipeSteps.FirstOrDefault(entry => entry.RecipeStepId == joinId);
      _db.RecipeSteps.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
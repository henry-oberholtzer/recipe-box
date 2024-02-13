using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow; //for search bar

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    public RecipesController(RecipeBoxContext db)
    {
      _db = db;
    }

    private static Dictionary<string, object> RecipeFormModel(Recipe recipe, string action)
    {
      return new Dictionary<string, object> {
        {"Action", action},
        {"Recipe", recipe}
      };
    }
    public ActionResult Index()
    {
      List<Recipe> model = _db.Recipes.ToList();
      return View(model);
    }
    public ActionResult Create()
    {

      return View(RecipeFormModel(new Recipe(), "Create"));
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      if (!ModelState.IsValid)
      {
        return View(RecipeFormModel(recipe, "Create"));
      }
      else
      {
        {
          _db.Recipes.Add(recipe);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
    }
    public ActionResult Details(int id)
    {
      Recipe thisRecipe = _db.Recipes
      .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }
    public ActionResult Edit(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(RecipeFormModel(thisRecipe, "Edit"));
    }
    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Recipes.Update(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddStep(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      List<Step> steps = _db.Steps.ToList();
      ViewBag.Steps = steps;
      return View(thisRecipe);
    }
    [HttpPost]
    public ActionResult AddStep(Recipe recipe, int[] stepIds)
    {
      if (stepIds != null && stepIds.Length > 0)
      {
        foreach (int stepId in stepIds)
        {
#nullable enable
          RecipeStep? joinEntity = _db.RecipeSteps.FirstOrDefault(join => join.StepId == stepId && join.RecipeId == recipe.RecipeId);
#nullable disable
          if (joinEntity == null)
          {
            _db.RecipeSteps.Add(new RecipeStep() { StepId = stepId, RecipeId = recipe.RecipeId });
            _db.SaveChanges();
          }
        }
      }
      return RedirectToAction("Details", new { id = recipe.RecipeId });
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

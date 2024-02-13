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
      .Include(recipe => recipe.MealRecipes)
      .ThenInclude(join => join.Meal)
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
    public ActionResult AddMeal(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      return View(thisRecipe);
    }
    [HttpPost]
    public ActionResult AddMeal(Recipe recipe, string[] mealNames)
    {
      if (mealNames != null && mealNames.Length > 0)
      {
        foreach (string mealName in mealNames)
        {
          Meal meal = new Meal
          {
            Name = mealName
          };
          _db.Meals.Add(meal);
          _db.SaveChanges();
          int mealId = meal.MealId;
#nullable enable
          MealRecipe? joinEntity = _db.MealRecipes.FirstOrDefault(join => join.MealId == mealId && join.RecipeId == recipe.RecipeId);
#nullable disable
          if (joinEntity == null & mealId != 0)
          {
            _db.MealRecipes.Add(new MealRecipe() { MealId = mealId, RecipeId = recipe.RecipeId });
          }
        }
        _db.SaveChanges();

        return RedirectToAction("Details", new
        {
          id = recipe.RecipeId
        });
      }
      else
      {
        ModelState.AddModelError("", "Please select at least one meal type.");
        return View(recipe);
      }
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      MealRecipe joinEntry = _db.MealRecipes.FirstOrDefault(entry => entry.MealRecipeId == joinId);
      _db.MealRecipes.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



  }
}

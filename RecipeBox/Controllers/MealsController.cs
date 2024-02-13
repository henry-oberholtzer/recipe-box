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

namespace RecipeBox.Controllers;

  public class MealsController : Controller
  {
    private readonly RecipeBoxContext _db;
    public MealsController(RecipeBoxContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Meals.ToList());
    }
    public ActionResult Details(int id)
    {
      Meal thisMeal = _db.Meals
      .Include(meal => meal.MealRecipes)
      .ThenInclude(join => join.Recipe)
      .FirstOrDefault(meal => meal.MealId == id);
      return View(thisMeal);
    }
    public ActionResult AddRecipe(int id)
    {
      Meal thisMeal = _db.Meals.FirstOrDefault(meals => meals.MealId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Title");
      return View(thisMeal);
    }
    [HttpPost]
    public ActionResult AddRecipe(Meal meal, int recipeId)
    {
      #nullable enable
      MealRecipe? joinEntity = _db.MealRecipes.FirstOrDefault(join => (join.RecipeId == recipeId && join.MealId == meal.MealId));
      #nullable disable
      if (joinEntity == null && recipeId != 0)
      {
        _db.MealRecipes.Add(new MealRecipe() { RecipeId = recipeId, MealId = meal.MealId });
        _db.SaveChanges();
      }
  
      return RedirectToAction("Details", new { id = meal.MealId });
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;

namespace RecipeBox.Controllers;

public class IngredientsController : Controller
{
  private readonly RecipeBoxContext _db;
  public IngredientsController(RecipeBoxContext db)
  {
    _db = db;
  }

  private static Dictionary<string, object> IngredientFormModel(Ingredient ingredient, string action)
  {
    return new Dictionary<string, object> {
      {"Ingredient", ingredient},
      {"Action", action}
    };
  }
  public ActionResult Index()
  {
    List<Ingredient> model = _db.Ingredients
    .Include(i => i.IngredientRecipes)
    .ToList();
    return View(model);
  }

  public ActionResult Create()
  {
    return View(IngredientFormModel(new Ingredient(), "Create"));
  }

  [HttpPost]
  public ActionResult Create(Ingredient ingredient)
  {
    if(!ModelState.IsValid)
    {
      return View(IngredientFormModel(ingredient, "Create"));
    }
    _db.Ingredients.Add(ingredient);
    _db.SaveChanges();
    return RedirectToAction("Details", new { id = ingredient.IngredientId});
  }

  public ActionResult Edit(int id)
  {
    Ingredient target = _db.Ingredients.FirstOrDefault(i => i.IngredientId == id);
    return View(IngredientFormModel(target, "Edit"));
  }
  [HttpPost]
  public ActionResult Edit(Ingredient ingredient)
  {
    if (!ModelState.IsValid)
    {
      return View(IngredientFormModel(ingredient, "Edit"));
    }
    _db.Ingredients.Update(ingredient);
    _db.SaveChanges();
    return RedirectToAction("Details", new { id = ingredient.IngredientId});
  }

  public ActionResult Details(int id)
  {
    Ingredient ingredient = _db.Ingredients
    .Include(i => i.IngredientRecipes)
    .ThenInclude(iR => iR.Recipe)
    .FirstOrDefault(i => i.IngredientId == id);
    return View(ingredient);
  }

  [HttpPost]
  public ActionResult Delete(int id)
  {
    Ingredient target = _db.Ingredients.Include(i => i.IngredientRecipes).FirstOrDefault(i => i.IngredientId == id);
    if(target.IngredientRecipes.Count == 0)
    {
      _db.Ingredients.Remove(target);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    else
    {
      return RedirectToAction("Details", new { id = target.IngredientId});
    }
  }

  // [HttpPost]
  // public ActionResult AddIngredientRecipe(IngredientRecipe ingRec)
  // {
  //   if(!ModelState.IsValid)
  //   {
  //   }
  //   _db.IngredientRecipes.Add(ingRec);
  //   _db.SaveChanges();
  //   return RedirectToAction
  // } 

}

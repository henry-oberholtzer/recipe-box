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

}

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
  public ActionResult Index()
  {
    List<Ingredient> model = _db.Ingredients
    .Include(i => i.IngredientRecipes)
    .ToList();
    return View(model);
  }


}

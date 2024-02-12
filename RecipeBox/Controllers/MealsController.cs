using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow; //for search bar

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
  }
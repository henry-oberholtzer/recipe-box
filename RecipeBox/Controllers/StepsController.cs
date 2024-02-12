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
  }
}
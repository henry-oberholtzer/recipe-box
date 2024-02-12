using System;
using System.Collections.Generic;

namespace RecipeBox.Models;

public class Type
{
  public int TypeId { get; set; }
  public string Name { get; set; }
  public List<RecipeType> JoinEntities { get; }
}

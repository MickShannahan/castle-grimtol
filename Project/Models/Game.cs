using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Game
  {
    public bool Running { get; set; }
    public Player Player { get; set; }
    public Room CurrentRoom { get; set; }
    public List<String> Commands { get; set; }
  }
}
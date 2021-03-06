using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces
{
  public interface IItem
  {
    string Name { get; set; }
    string Description { get; set; }
    int Health { get; set; }
    int Damage { get; set; }


    string TakeItem(Player player)
    {
      player.Inventory.Add(this);
      return $"You take {Name}";
    }
  }
}
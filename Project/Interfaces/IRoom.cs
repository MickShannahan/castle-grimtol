using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<IItem> Items { get; set; }
    Dictionary<string, NPC> NPCs { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
    Dictionary<string, bool> Locked { get; set; }

    string RoomDesc()
    {
      string message = $"You find thy self in the {Name}, {Description}. ";
      if (Items.Count > 0)
      {
        message += "You see a ";
        Items.ForEach(item =>
        {
          message += item.Name + ". ";
        });
      }

      message += "There are exits to the ";
      foreach (var exit in Exits)
      {
        message += exit.Key;
      };
      return message;
    }
  }
}

using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }

    public List<NPC> NPCs { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public Dictionary<string, bool> Locked { get; set; }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public string EnterRoom()
    {
      string message = $"You enter {Name}, {Description}. ";
      if (Items.Count > 0)
      {
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

    public string UnlockRoom(string key)
    {
      if (Locked.ContainsKey(key))
      {
        Locked[key] = false;
        return $"{Name} is now open...";
      }
      return $"{Name} remains locked";
    }
  }
}
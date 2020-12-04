using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, NPC> NPCs { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public Dictionary<string, bool> Locked { get; set; }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, IRoom>();
      Locked = new Dictionary<string, bool>();
      NPCs = new Dictionary<NPC, bool>();
      Items = new List<IItem>();
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
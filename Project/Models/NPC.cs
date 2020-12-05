using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class NPC : IPlayer
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public string Class { get; set; }
    public IItem Weapon { get; set; }
    public bool Hostile { get; set; }
    public IRoom Room { get; set; }

    public NPC(string name, int health, bool hostile, IItem weapon)
    {
      Name = name;
      MaxHealth = health;
      CurrentHealth = health;
      Hostile = hostile;
      weapon = weapon != null ? weapon : new Item(null, null, 0, 0);
    }

    public string TakeDamage(int damage)
    {
      CurrentHealth -= damage;
      return $"You strike {Name}, it takes {damage} damage";
    }

    public string DropItems()
    {
      string message = $"{Name} dropped ";
      Inventory.ForEach(item =>
      {
        message += item.Name + " ";
        Room.Items.Add(item);
      });
      return message;
    }
  }
}
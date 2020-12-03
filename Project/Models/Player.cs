using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player
  {
    public string PlayerName { get; set; }
    public List<IItem> Inventory { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public string Class { get; set; }
    public IItem Weapon { get; set; }

    public Player(string name, int health, string playerClass)
    {
      PlayerName = name;
      MaxHealth = health;
      CurrentHealth = health;
      Class = playerClass;
    }

    public string TakeDamage(int damage)
    {
      CurrentHealth -= damage;
      return $"You been struck taking {damage} damage";
    }

    public string TakeItem(IItem item)
    {
      Inventory.Add(item);
      return $"{item.Name} was added to you inventory";
    }

    public string RemoveItem(IItem item)
    {
      Inventory.Remove(item);
      return $"{item.Name} was removed from your inventory";
    }
  }
}
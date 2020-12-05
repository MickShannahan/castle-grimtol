using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player
  {
    public string Name { get; set; }
    public List<IItem> Inventory { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public string Class { get; set; }
    public IItem Weapon { get; set; }
    public ConsoleColor FavColor { get; set; }


    public Player(string name, int health, string playerClass, ConsoleColor color)
    {
      Name = name;
      MaxHealth = health;
      CurrentHealth = health;
      Class = playerClass;
      FavColor = color;
      Inventory = new List<IItem>();
    }

    public string TakeDamage(int damage)
    {
      if (damage > 0)
      {
        CurrentHealth -= damage;
        return $"You Have been struck taking {damage} damage";
      }
      return $"";
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
    public string ListInventory()
    {
      string message = "";
      Inventory.ForEach(item =>
      {
        message += "  " + item.Name + "\n";
      });
      return message;
    }

    public string EquipItem(IItem item)
    {
      if (Inventory.Contains(item))
      {
        Inventory.Add(Weapon);
        Weapon = item;
        Inventory.Remove(item);
        return $"{item.Name} was equipted";
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You don't have that item");
        return "";
      }
    }
  }
}
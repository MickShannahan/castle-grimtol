using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Game
  {
    public bool Running { get; set; }
    public Player Player { get; set; }
    public IRoom CurrentRoom { get; set; }
    public List<String> Commands { get; set; } = new List<string>();
    public Game(Player player)
    {
      Running = true;
      Player = player;

    }

    public string ChangeRoom(IRoom room)
    {
      foreach (var item in room.Locked)
      {
        if (item.Value == true)
        {
          return $"You cannot enter {room.Name} the way is locked";
        }
      }
      CurrentRoom = room;
      return $"You enter {room.Name}";
    }

    public string ListCommands()
    {
      string message = "You can ";
      Commands.ForEach(command =>
      {
        message += command + "\n ";
      });
      return message;
    }
  }
}
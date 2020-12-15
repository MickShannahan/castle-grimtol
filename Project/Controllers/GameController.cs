using CastleGrimtol.Services;
using CastleGrimtol.Project.Models;
using System;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Controllers
{


  public class GameController
  {

    public string[] choices = new string[3] { "thing", "thing2", "thing3" };

    public GameController()
    {
      StartGame();
    }

    public void StartGame()
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine(@"                       Welcome to castle");
      Console.WriteLine(@"
            ________      .__         __         .__             
           /  _____/______|__| ______/  |_  ____ |  |            
  ______  /   \  __\_  __ \  |/     \   __\/  _ \|  |     ______ 
 /_____/  \    \_\  \  | \/  |  Y Y  \  | (  <_> )  |__  /_____/ 
           \______  /__|  |__|__|_|  /__|  \____/|____/          
                  \/               \/                            ");
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine(@"
      what would you like to do?
          1. Start a new Game
          2. Continue a Game");
      string input = Console.ReadLine();
      switch (input)
      {
        case "1":
          NewGame();
          break;
        case "2":
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("not yet implemented");
          break;
      }
    }
    public void NewGame()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("What is thy Name Grand adventurer?");
      Console.ForegroundColor = ConsoleColor.Gray;
      string name = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("What Class brand of hero are you?");
      Console.WriteLine(@"
      1. Fighter - you accell at combat and can wield any martial weapon.
      2. Wizard - this is the best class just pick this one.
      3. Goblin - this is the a trash class for trash people.
      ");
      Console.ForegroundColor = ConsoleColor.Gray;
      string classInput = Console.ReadLine();
      int health = 100;
      switch (classInput)
      {
        case "1":
          classInput = "Fighter";
          health = 150;
          break;
        case "2":
          classInput = "Wizard";
          health = 75;
          break;
        case "3":
          classInput = "Goblin";
          health = 25;
          break;
      }
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("What is your Favorite Color?");
      Console.WriteLine(@"
      1.red
      2.green
      3.blue
      4.yellow
      5.purple");
      Console.ForegroundColor = ConsoleColor.Gray;
      string colorInput = Console.ReadLine();
      ConsoleColor color = ConsoleColor.Gray;
      switch (colorInput)
      {
        case "1":
          color = ConsoleColor.Red;
          break;
        case "2":
          color = ConsoleColor.Green;
          break;
        case "3":
          color = ConsoleColor.DarkBlue;
          break;
        case "4":
          color = ConsoleColor.Yellow;
          break;
        case "5":
          color = ConsoleColor.DarkMagenta;
          break;
      }
      Player player = new Player(name, health, classInput, color);
      Game game = new Game(player);
      GameSetup(game);
      RunGame(game);

    }


    public void RunGame(Game game)
    {
      game.Running = true;
      while (game.Running)
      {
        GetUserInput(game);
      }
    }

    public void GetUserInput(Game game)
    {
      Console.ForegroundColor = game.Player.FavColor;
      Console.WriteLine("What would you like to do?");
      Console.ForegroundColor = ConsoleColor.Gray;
      string input = Console.ReadLine().ToLower();
      string command = input.Split(" ")[0];
      switch (command)
      {
        case "go":
          Go(game, input.Split(" ")[1]);
          break;
        case "look":
          Look(game);
          break;
        case "help":
          Help(game);
          break;
        case "talk":
          Talk(game, input.Split(" ")[1]);
          break;
        case "take":
          if (input.Split(" ").Length > 1)
          {
            TakeItem(game, input.Split(" ")[1]);
          }
          break;
        case "inventory":
          Inventory(game.Player);
          break;
        case "equip":
          Equip(game.Player, input.Split(" ")[1]);
          break;
        case "strike":
          Attack(game, input.Split(" ")[1]);
          break;
        case "use":
          UseItem(game, input.Split(" ")[1]);
          break;
        default:
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("Thy Command was not recognized");
          Console.ForegroundColor = ConsoleColor.Gray;
          break;
      }
    }


    private void Talk(Game game, string Character)
    {
      if (game.CurrentRoom.NPCs.Count > 0)
      {
        Console.WriteLine("This NPC does not want to talk to you");
      }
      else
      {
        Console.WriteLine("There is no one to talk to but thyself");
      }
    }


    public void Go(Game game, string direction)
    {
      if (game.CurrentRoom.Exits.ContainsKey(direction))
      {
        Console.WriteLine(game.ChangeRoom(game.CurrentRoom.Exits[direction]));
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Thy Path {direction} does not exist...");
      }
    }


    public void Help(Game game)
    {
      string message = "";
      game.Commands.ForEach(com =>
      {
        message += com + "\n";
      });
      Console.WriteLine(message);
    }


    public void Inventory(Player player)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("You are carrying ");
      if (player.Inventory.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Nothing");
      }
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine(player.ListInventory());
    }

    public void UseItem(Game game, string itemName)
    {
      // TODO Expand this
      IItem item = game.Player.Inventory.Find(i => i.Name == itemName);
      Console.WriteLine($"You Used the {item.Name}");
    }


    private void Equip(Player player, string itemName)
    {
      IItem item = player.Inventory.Find(i => i.Name == itemName);
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine(player.EquipItem(item));
    }


    public void Look(Game game)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine(game.CurrentRoom.RoomDesc() + @"
      ");
      Console.ForegroundColor = ConsoleColor.Gray;
    }

    public void Attack(Game game, string targetString)
    {
      Player player = game.Player;
      if (game.CurrentRoom.NPCs.ContainsKey(targetString))
      {
        NPC target = game.CurrentRoom.NPCs[targetString];
        target.TakeDamage(player.Weapon.Damage);
        if (target.CurrentHealth > 0)
        {
          player.TakeDamage(target.Weapon.Damage);
        }
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{targetString} is not a valid target");
      }
    }

    public void Quit(Game game)
    {
      game.Running = false;
    }

    public void TakeItem(Game game, string itemName)
    {
      IItem item = game.CurrentRoom.Items.Find(i => i.Name == itemName);
      if (game.CurrentRoom.Items.Contains(item))
      {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(game.Player.TakeItem(item));
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("That Item is not here");
      }

    }

    private void GameSetup(Game game)
    {
      // Room Creation -------------------------------------------------------
      Room startRoom = new Room("Dungeon Cell", "The Cell is dark dark, you can barley make out the dark outline of your own hand. A dank smell wafts from the corner.  The bars to the cell are covered with rust and a slow but stead dripping echoes through.");
      Room Dungeon = new Room("Dungeon Keep", "The Greater Dungeon Keep is lined with dark dark dungeon cells. Thy nose still stings from the stench");
      Dungeon.Locked.Add("stool", true);
      // Exits ---------------------------------------------------------------
      startRoom.Exits.Add("north", Dungeon);
      // Items ---------------------------------------------------------------
      Item stool = new Item("stool", "Made of worn wood and covered in splinters.", 5, 2);
      startRoom.Items.Add(stool);
      //NPCs -----------------------------------------------------------------
      NPC DungeonCellDoor = new NPC("Dungeon Cell Door", 10, true, null);
      startRoom.NPCs.Add("Door", DungeonCellDoor);
      // COMMANDS ------------------------------------------------------------
      game.Commands.Add("Go");
      game.Commands.Add("Take");
      game.Commands.Add("Look");
      game.Commands.Add("Talk");
      game.Commands.Add("Strike <target>");
      game.Commands.Add("Inventory");
      game.Commands.Add("Equip <item from inventory>");
      game.Commands.Add("Use <item from inventory>");
      game.Commands.Add("Help");
      game.Commands.Add("Quit");
      Console.Clear();
      game.ChangeRoom(startRoom);
      Look(game);
    }
  }
}
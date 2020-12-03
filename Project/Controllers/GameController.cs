using CastleGrimtol.Services;
using CastleGrimtol.Project.Models;
using System;

namespace CastleGrimtol.Controllers
{


  public class GameController
  {

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
      Console.WriteLine("What is your Name Grand adventurer?");
      string name = Console.ReadLine();
      Console.WriteLine("What Class brand of hero are you?");
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine(@"
      1. Fighter - you accell at combat and can wield any martial weapon.
      2. Wizard - this is the best class just pick this one.
      3. Goblin - this is the a trash class for trash people.
      ");
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
      Player player = new Player(name, health, classInput);
      GameSetup();
      Game game = new Game(player);
      RunGame(game);

    }


    public void RunGame(Game game)
    {
      game.Running = true;
      while (game.Running)
      {

      }
    }

    public void GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup()
    {
      throw new System.NotImplementedException();
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    private void GameSetup()
    {
      // Room Creation -------------------------------------------------------
      Room startRoom = new Room("Dungeon Cell", "You find yourself in a dark dark dungeon cell.  A dank smell wafts from the corner.  The bars to the cell are covered with rust and a slow but stead dripping echoes through.", false);
      Room Dungeon = new Room("Dungeon Cell", "The Greater Dungeon hall is lined with dark dark dungeon cells. Thy nose still stings from the stench", true);
      // Exits ---------------------------------------------------------------
      startRoom.Exits.Add("north", Dungeon);
      // Items ---------------------------------------------------------------
      Item stool = new Item("stool", "Made of worn wood and covered in splinters.", 5, 2);
      startRoom.Items.Add(stool);
      //NPCs -----------------------------------------------------------------
      NPC DungeonCellDoor = new NPC("Dungeon Cell Door", 10, false, startRoom);
    }
  }
}
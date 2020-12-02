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
      Console.WriteLine("Welcome to castle Grimtol");
      Console.ReadLine();
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
  }
}
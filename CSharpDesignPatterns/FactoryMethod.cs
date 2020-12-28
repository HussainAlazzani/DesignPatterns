using System;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class FactoryMethodTest
    {
        public static void Run()
        {
            var monopoly = new CreateBoardGame("Monopoly");
            monopoly.Play();

            var snakesLadders = new CreateBoardGame("SnakesAndLadders");
            snakesLadders.Play();
        }
    }

    /// <summary>
    /// This class represents the creator class
    /// </summary>
    public class CreateBoardGame
    {
        private BoardGame game;

        public CreateBoardGame(string type)
        {
            switch (type.ToLower())
            {
                case "monopoly":
                    game = new Monopoly();
                    break;
                case "snakesandladders":
                    game = new SnakesAndLadders();
                    break;
                default:
                    throw new Exception("Game not found");
            }
        }

        public void Play()
        {
            game.Play();
        }
    }

    /// <summary>
    /// The product class
    /// </summary>
    public abstract class BoardGame
    {
        public abstract string Name { get; }

        public abstract void Play();
    }

    /// <summary>
    /// Concreate implementation of product A
    /// </summary>
    public class Monopoly : BoardGame
    {
        public Monopoly()
        { }

        public override string Name => "Monopoly";
        public override void Play()
        {
            System.Console.WriteLine($"Play monopoly...");
        }
    }

    /// <summary>
    /// Concreate implementation of product B
    /// </summary>
    public class SnakesAndLadders : BoardGame
    {
        public SnakesAndLadders()
        { }

        public override string Name => "SnakesAndLadders";

        public override void Play()
        {
            System.Console.WriteLine($"Play snakes and ladders...");
        }
    }
}
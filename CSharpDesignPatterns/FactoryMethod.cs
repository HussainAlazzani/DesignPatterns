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
    internal class CreateBoardGame
    {
        private BoardGame game;

        internal CreateBoardGame(string type)
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

        internal void Play()
        {
            game.Play();
        }
    }

    /// <summary>
    /// The product class
    /// </summary>
    internal abstract class BoardGame
    {
        internal abstract string Name { get; }

        internal abstract void Play();
    }

    /// <summary>
    /// Concreate implementation of product A
    /// </summary>
    internal class Monopoly : BoardGame
    {
        internal Monopoly()
        { }

        internal override string Name => "Monopoly";
        internal override void Play()
        {
            System.Console.WriteLine($"Play monopoly...");
        }
    }

    /// <summary>
    /// Concreate implementation of product B
    /// </summary>
    internal class SnakesAndLadders : BoardGame
    {
        internal SnakesAndLadders()
        { }

        internal override string Name => "SnakesAndLadders";

        internal override void Play()
        {
            System.Console.WriteLine($"Play snakes and ladders...");
        }
    }
}
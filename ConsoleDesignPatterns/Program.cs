using System;
using CSharpDesignPatterns;

namespace ConsoleDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}



/* -----------------------------------------------
// Test factory method

static void Main(string[] args)
{
    var monopoly = new CreateBoardGame("Monopoly");
    monopoly.Play();

    var snakesLadders = new CreateBoardGame("SnakesAndLadders");
    snakesLadders.Play();
}
----------------------------------------------- */

/* -----------------------------------------------
// Test abstract factory

static void Main(string[] args)
{
    IUniformFactory factory = new OfficeUniformFactory();
    var uniform = new CreateFullUniform(factory, 15, 10);
    uniform.Display();

    factory = new WorkshopUniformFactory();
    uniform = new CreateFullUniform(factory, 15, 10);
    uniform.Display();
}
----------------------------------------------- */

/* -----------------------------------------------
// Test Singleton

static void Main(string[] args)
{
    var s1 = Singleton.GetInstance();
    var s2 = Singleton.GetInstance();
    
    // returns true
    System.Console.WriteLine(s1 == s2);
    
    // Cannot access constructor because it is private.
    // var s3 = new Singleton();

}
----------------------------------------------- */

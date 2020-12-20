using System;
using System.Collections.Generic;
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

/* -----------------------------------------------
// Test Builder

static void Main(string[] args)
{
    IBuilder builder = new ComputerBuilder();
    var director = new Director();
    
    director.BuildGamingPC(builder);
    var gamingPC = builder.Computer;
    gamingPC.Display();
    
    director.BuildHomePC(builder);
    var homePC = builder.Computer;
    homePC.Display();    
}
----------------------------------------------- */

/* -----------------------------------------------
// Test factory method

static void Main(string[] args)
{
    Car car1 = new Car("Black");

    // Create a new copy of the car
    var car2 = car1.Clone() as Car;
    car2.Colour = "White";

    System.Console.WriteLine(car1);
    System.Console.WriteLine(car2);
}
----------------------------------------------- */

/* -----------------------------------------------
// Test Adaptor

static void Main(string[] args)
{
    var xmlGraphs = new XmlGraphs();
    var graphViewer = new JsonGraphs(xmlGraphs);
    
    var jsonData = "data in json text";

    graphViewer.DisplayBarChart(jsonData);
    graphViewer.DisplayPieChart(jsonData);
}
----------------------------------------------- */

/* -----------------------------------------------
// Test Bridge

static void Main(string[] args)
{
    BankAccount account;

    var currentAc = new CurrentAccount();
    account = new BankAccount(currentAc);
    account.Deposite(100m);
    account.Withdraw(30m);
    account.ShowBalance();

    var savingsAc = new SavingsAccount();
    account = new BankAccount(savingsAc);
    account.Deposite(2000m);
    account.ShowBalance();
}
----------------------------------------------- */

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
// Test Prototype

static void Main(string[] args)
{
    Bus bus1 = new Bus("Red");

    // Create a new copy of the bus
    var bus2 = bus1.Clone() as Bus;
    bus2.Colour = "Yellow";

    System.Console.WriteLine(bus1);
    System.Console.WriteLine(bus2);
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

/* -----------------------------------------------
// Test Composition

static void Main(string[] args)
{
    IFamilyMember jason = new Child("Jason", new DateTime(2001, 12, 4));
    IFamilyMember natalie = new Child("Natalie", new DateTime(2005, 5, 23));
    IFamilyMember kumar = new Child("Kumar", new DateTime(2002, 1, 18));

    IFamilyMember peter = new Parent("Peter", new DateTime(1970, 5, 11));
    peter.AddChild(jason);
    peter.AddChild(natalie);

    IFamilyMember ann = new Parent("Ann", new DateTime(1968, 11, 13));
    ann.AddChild(kumar);

    IFamilyMember margaret = new Parent("Margaret", new DateTime(1940, 3, 02));
    margaret.AddChild(peter);
    margaret.AddChild(ann);

    // Display Margaret's children and grandchildren
    margaret.GetDetails();
    System.Console.WriteLine();
    // Display Jason's details
    jason.GetDetails();
}
----------------------------------------------- */

/* -----------------------------------------------
// Test Iterator

static void Main(string[] args)
{
    ReadingList readingList = new ReadingList();
    readingList.Add("C# For Professionals");
    readingList.Add("Sapiens, A Brief History Of Humankind");
    readingList.Add("Head First Design Patterns");
    readingList.Add("Thinking, Fast and Slow");
    readingList.Add("A Random Walk Down Wall Street");

    IIterator iterator = readingList.CreateIterator();

    while (iterator.HasNext())
    {
        System.Console.WriteLine(iterator.Current());
        iterator.Next();
    }
}
----------------------------------------------- */

/* -----------------------------------------------
// Test decorator

static void Main(string[] args)
{
    Car basicCar = new Car();
    Car privateCar = new Car();
    Car companyCar = new Car();

    IInsurance basicInsurance = new BasicInsurance();
    InsuranceDecorator privateInsurance = new PrivateComprehensive(basicInsurance);
    InsuranceDecorator companyInsurance = new CompanyComprehensive(basicInsurance);

    // Add basic cover
    basicInsurance.AddQuote(basicCar);
    System.Console.WriteLine(basicCar.Price);

    // Add private cover
    privateInsurance.AddQuote(privateCar);
    System.Console.WriteLine(privateCar.Price);

    // Add company cover
    companyInsurance.AddQuote(companyCar);
    System.Console.WriteLine(companyCar.Price);
}
----------------------------------------------- */

/* -----------------------------------------------
// Test Facade

static void Main(string[] args)
{
    System.Console.Write("Enter account to transfer from: ");
    string accountA = Console.ReadLine();
    System.Console.Write("Enter account to transfer to: ");
    string accountB = Console.ReadLine();
    System.Console.Write("Enter amount: ");
    decimal amount;
    if (Decimal.TryParse(Console.ReadLine(), out amount))
    {
        FinancialServices service = new FinancialServices();
        service.Transfer(accountA, accountB, amount);    
    }   
}
----------------------------------------------- */

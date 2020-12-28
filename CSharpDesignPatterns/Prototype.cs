using System;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class PrototypeTest
    {
        public static void Run()
        {
            Bus bus1 = new Bus("Red");

            // Create a new copy of the bus
            var bus2 = bus1.Clone() as Bus;
            bus2.Colour = "Yellow";

            System.Console.WriteLine(bus1);
            System.Console.WriteLine(bus2);
        }
    }

    /// <summary>
    /// Prototype
    /// </summary>
    public abstract class Vehicle : ICloneable
    {
        public string Colour { get; set; }

        public Vehicle(string colour)
        {
            this.Colour = colour;
        }

        // A copy constructor to be used for cloning
        public Vehicle(Vehicle source)
        {
            this.Colour = source.Colour;
        }

        public abstract object Clone();
    }

    public class Bus : Vehicle
    {
        public Bus(string colour) : base(colour)
        { }

        // Copy constructor to be used for cloning
        public Bus(Bus source) : base(source)
        { }

        public override string ToString()
        {
            return $"This is a bus. Its colour is: {base.Colour}.";
        }

        public override object Clone()
        {
            return new Bus(this);
        }
    }
}
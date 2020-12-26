using System;

namespace CSharpDesignPatterns
{
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
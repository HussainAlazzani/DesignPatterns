using System;

namespace CSharpDesignPatterns
{
    internal class Car
    {
        internal Car()
        {
            this.Make = "BMW";
            this.Model = "3 Series";
            this.Year = new DateTime(2020, 9, 1);
            this.Colour = "Silver";
            this.Price = 30000m;
        }

        internal Car(string make, string model, DateTime year, string colour, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Colour = colour;
            this.Price = price;
        }

        internal string Make { get; set; }
        internal string Model { get; set; }
        internal DateTime Year { get; set; }
        internal string Colour { get; set; }
        internal decimal Price { get; set; }
    }
}
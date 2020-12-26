using System;

namespace CSharpDesignPatterns
{
    public class Car
    {
        public Car()
        {
            this.Make = "BMW";
            this.Model = "3 Series";
            this.Year = new DateTime(2020, 9, 1);
            this.Colour = "Silver";
            this.Price = 30000m;
        }

        public Car(string make, string model, DateTime year, string colour, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Colour = colour;
            this.Price = price;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }
}
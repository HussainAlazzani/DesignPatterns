using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class BuilderTest
    {
        public static void Run()
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
    }

    /// <summary>
    /// Director
    /// </summary>
    internal class Director
    {
        internal void BuildGamingPC(IBuilder builder)
        {
            builder
                .BuildMotherboard(new Motherboard("001"))
                .BuildCPU(new CPU("Intel i9"))
                .BuildRAM(new RAM(32))
                .BuildStorage(new Storage("SSD", 1000))
                .BuildGraphics(new Graphics("Nvidia"));
        }

        internal void BuildHomePC(IBuilder builder)
        {
            builder
                .BuildMotherboard(new Motherboard("002"))
                .BuildCPU(new CPU("AMD Ryzen 3"))
                .BuildRAM(new RAM(16))
                .BuildStorage(new Storage("HDD", 500))
                .BuildGraphics(new Graphics("GT1030"));
        }
    }

    /// <summary>
    /// For fluent design, we set IBuilder as the return type, and in the implementation
    /// we return "this" which will return the IBuilder object which we can then chain.
    /// </summary>
    internal interface IBuilder
    {
        Computer Computer { get; }
        IBuilder BuildMotherboard(Motherboard mb);
        IBuilder BuildCPU(CPU cpu);
        IBuilder BuildRAM(RAM ram);
        IBuilder BuildStorage(Storage storage);
        IBuilder BuildGraphics(Graphics gpu);
        void Reset();
    }

    internal class ComputerBuilder : IBuilder
    {
        public Computer Computer { get; }

        internal ComputerBuilder()
        {
            this.Computer = new Computer();
        }

        public IBuilder BuildMotherboard(Motherboard mb)
        {
            Computer.Add(mb);
            return this;
        }

        public IBuilder BuildCPU(CPU cpu)
        {
            Computer.Add(cpu);
            return this;
        }

        public IBuilder BuildRAM(RAM ram)
        {
            Computer.Add(ram);
            return this;
        }

        public IBuilder BuildStorage(Storage storage)
        {
            Computer.Add(storage);
            return this;
        }

        public IBuilder BuildGraphics(Graphics gpu)
        {
            Computer.Add(gpu);
            return this;
        }

        public void Reset()
        {
            Computer.Reset();
        }
    }

    internal class Computer
    {
        private IList<object> components = new List<object>();

        internal Computer computer { get; }

        internal void Add(object part)
        {
            components.Add(part);
        }

        internal void Reset()
        {
            components.Clear();
        }

        internal void Display()
        {
            foreach (var component in components)
            {
                System.Console.WriteLine(component);
            }
        }
    }

    internal class Motherboard
    {
        internal string Id { get; }

        internal Motherboard(string id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Motherboard, product number: {this.Id}. ";
        }
    }

    internal class CPU
    {
        internal string Brand { get; }

        internal CPU(string brand)
        {
            this.Brand = brand;
        }

        public override string ToString()
        {
            return $"CPU: {this.Brand}. ";
        }
    }

    internal class RAM
    {
        internal int Size { get; }

        internal RAM(int size)
        {
            this.Size = size;
        }

        public override string ToString()
        {
            return $"RAM: {this.Size}. ";
        }
    }

    internal class Storage
    {
        internal string Type { get; }
        internal int Size { get; }

        internal Storage(string type, int size)
        {
            this.Size = size;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Storage type: {this.Type}, Size: {this.Size}.";
        }
    }

    internal class Graphics
    {
        internal string Type { get; }

        internal Graphics(string type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Graphics processor: {this.Type}. ";
        }
    }
}
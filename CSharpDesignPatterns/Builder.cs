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
    public class Director
    {
        public void BuildGamingPC(IBuilder builder)
        {
            builder
                .BuildMotherboard(new Motherboard("001"))
                .BuildCPU(new CPU("Intel i9"))
                .BuildRAM(new RAM(32))
                .BuildStorage(new Storage("SSD", 1000))
                .BuildGraphics(new Graphics("Nvidia"));
        }

        public void BuildHomePC(IBuilder builder)
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
    public interface IBuilder
    {
        Computer Computer { get; }
        IBuilder BuildMotherboard(Motherboard mb);
        IBuilder BuildCPU(CPU cpu);
        IBuilder BuildRAM(RAM ram);
        IBuilder BuildStorage(Storage storage);
        IBuilder BuildGraphics(Graphics gpu);
        void Reset();
    }

    public class ComputerBuilder : IBuilder
    {
        public Computer Computer { get; }

        public ComputerBuilder()
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

    public class Computer
    {
        private IList<object> components = new List<object>();

        public Computer computer { get; }

        public void Add(object part)
        {
            components.Add(part);
        }

        public void Reset()
        {
            components.Clear();
        }

        public void Display()
        {
            foreach (var component in components)
            {
                System.Console.WriteLine(component);
            }
        }
    }

    public class Motherboard
    {
        public string Id { get; }

        public Motherboard(string id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Motherboard, product number: {this.Id}. ";
        }
    }

    public class CPU
    {
        public string Brand { get; }

        public CPU(string brand)
        {
            this.Brand = brand;
        }

        public override string ToString()
        {
            return $"CPU: {this.Brand}. ";
        }
    }

    public class RAM
    {
        public int Size { get; }

        public RAM(int size)
        {
            this.Size = size;
        }

        public override string ToString()
        {
            return $"RAM: {this.Size}. ";
        }
    }

    public class Storage
    {
        public string Type { get; }
        public int Size { get; }

        public Storage(string type, int size)
        {
            this.Size = size;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Storage type: {this.Type}, Size: {this.Size}.";
        }
    }

    public class Graphics
    {
        public string Type { get; }

        public Graphics(string type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Graphics processor: {this.Type}. ";
        }
    }
}
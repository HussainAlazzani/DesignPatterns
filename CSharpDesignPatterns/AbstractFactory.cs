namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class AbstractFactoryTest
    {
        public static void Run()
        {
            IUniformFactory factory = new OfficeUniformFactory();
            var uniform = new CreateFullUniform(factory, 15, 10);
            uniform.Display();

            factory = new WorkshopUniformFactory();
            uniform = new CreateFullUniform(factory, 15, 10);
            uniform.Display();
        }
    }

    /// <summary>
    /// Factory producer
    /// </summary>
    internal class CreateFullUniform
    {
        private IUniformFactory factory;
        private Shirt shirt;
        private Shoes shoes;

        internal CreateFullUniform(IUniformFactory factory, int shirtSize, int shoeSize)
        {
            this.factory = factory;
            shirt = factory.CreateShirt(shirtSize);
            shoes = factory.CreateShoes(shoeSize);
        }

        internal void Display()
        {
            shirt.Display();
            shoes.Display();
        }
    }

    /// <summary>
    /// Abstract factory
    /// </summary>
    internal interface IUniformFactory
    {
        Shirt CreateShirt(int size);
        Shoes CreateShoes(int size);
    }

    /// <summary>
    /// Concrete factory A
    /// </summary>
    internal class WorkshopUniformFactory : IUniformFactory
    {
        public Shirt CreateShirt(int size)
        {
            return new TShirt(size);
        }

        public Shoes CreateShoes(int size)
        {
            return new SafetyShoes(size);
        }
    }

    /// <summary>
    /// Concrete factory B
    /// </summary>
    internal class OfficeUniformFactory : IUniformFactory
    {
        public Shirt CreateShirt(int size)
        {
            return new FormalShirt(size);
        }

        public Shoes CreateShoes(int size)
        {
            return new FormalShoes(size);
        }
    }

    /// <summary>
    /// Abstract product A
    /// </summary>
    internal abstract class Shirt
    {
        internal int Size { get; }
        internal abstract string Color { get; }

        internal Shirt(int size)
        {
            this.Size = size;
        }

        internal abstract void Display();
    }
    /// <summary>
    /// Concrete product  A - type 1
    /// </summary>
    internal class FormalShirt : Shirt
    {
        internal FormalShirt(int size) : base(size) { }

        internal override string Color => "White";

        internal override void Display()
        {
            System.Console.WriteLine("Display image of a formal shirt");
        }
    }

    /// <summary>
    /// Concrete product A - type 2
    /// </summary>
    internal class TShirt : Shirt
    {
        internal TShirt(int size) : base(size) { }

        internal override string Color => "Blue";

        internal override void Display()
        {
            System.Console.WriteLine("Display image of a T-shirt");
        }
    }

    /// <summary>
    /// Abstract product B
    /// </summary>
    internal abstract class Shoes
    {
        internal int Size { get; }
        
        internal Shoes(int size)
        {
            Size = size;
        }

        internal abstract void Display();
    }

    /// <summary>
    /// Concrete product B - type 1
    /// </summary>
    internal class FormalShoes : Shoes
    {
        internal FormalShoes(int size) : base(size) { }

        internal override void Display()
        {
            System.Console.WriteLine("Display image of formal shoes");
        }
    }

    /// <summary>
    /// Concrete product B - type 2
    /// </summary>
    internal class SafetyShoes : Shoes
    {
        internal SafetyShoes(int size):base(size){}

        internal override void Display()
        {
            System.Console.WriteLine("Display image of safety shoes");
        }
    }
}
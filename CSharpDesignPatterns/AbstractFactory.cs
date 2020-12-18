namespace CSharpDesignPatterns
{
    /// <summary>
    /// Factory producer
    /// </summary>
    public class CreateFullUniform
    {
        private IUniformFactory factory;
        private Shirt shirt;
        private Shoes shoes;

        public CreateFullUniform(IUniformFactory factory, int shirtSize, int shoeSize)
        {
            this.factory = factory;
            shirt = factory.CreateShirt(shirtSize);
            shoes = factory.CreateShoes(shoeSize);
        }

        public void Display()
        {
            shirt.Display();
            shoes.Display();
        }
    }

    /// <summary>
    /// Abstract factory
    /// </summary>
    public interface IUniformFactory
    {
        Shirt CreateShirt(int size);
        Shoes CreateShoes(int size);
    }

    /// <summary>
    /// Concrete factory A
    /// </summary>
    public class WorkshopUniformFactory : IUniformFactory
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
    public class OfficeUniformFactory : IUniformFactory
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
    public abstract class Shirt
    {
        public int Size { get; }
        public abstract string Color { get; }

        public Shirt(int size)
        {
            this.Size = size;
        }

        public abstract void Display();
    }
    /// <summary>
    /// Concrete product  A - type 1
    /// </summary>
    public class FormalShirt : Shirt
    {
        public FormalShirt(int size) : base(size) { }

        public override string Color => "White";

        public override void Display()
        {
            System.Console.WriteLine("Display image of a formal shirt");
        }
    }

    /// <summary>
    /// Concrete product A - type 2
    /// </summary>
    public class TShirt : Shirt
    {
        public TShirt(int size) : base(size) { }

        public override string Color => "Blue";

        public override void Display()
        {
            System.Console.WriteLine("Display image of a T-shirt");
        }
    }

    /// <summary>
    /// Abstract product B
    /// </summary>
    public abstract class Shoes
    {
        public int Size { get; }
        
        public Shoes(int size)
        {
            Size = size;
        }

        public abstract void Display();
    }

    /// <summary>
    /// Concrete product B - type 1
    /// </summary>
    public class FormalShoes : Shoes
    {
        public FormalShoes(int size) : base(size) { }

        public override void Display()
        {
            System.Console.WriteLine("Display image of formal shoes");
        }
    }

    /// <summary>
    /// Concrete product B - type 2
    /// </summary>
    public class SafetyShoes : Shoes
    {
        public SafetyShoes(int size):base(size){}

        public override void Display()
        {
            System.Console.WriteLine("Display image of safety shoes");
        }
    }
}
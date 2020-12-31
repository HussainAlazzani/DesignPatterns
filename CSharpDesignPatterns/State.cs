namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class StateTest
    {
        public static void Run()
        {
            PhotoEditor canvas = new PhotoEditor();
            
            canvas.CurrentFilter = new Blur();
            canvas.Apply();

            canvas.CurrentFilter = new BlackAndWhite();
            canvas.Apply();

            canvas.CurrentFilter = new Sharpen();
            canvas.Apply();
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    internal class PhotoEditor
    {
        internal IFilter CurrentFilter { get; set; }

        internal void Apply()
        {
            CurrentFilter.Apply();
        }
    }

    /// <summary>
    /// State
    /// </summary>
    internal interface IFilter
    {
        // Using interface instead of abstract class since there are no fields nor implemented methods.
        void Apply();
    }

    /// <summary>
    /// Concrete State A
    /// </summary>
    internal class Blur : IFilter
    {
        public void Apply()
        {
            System.Console.WriteLine("Blur photo...");
        }
    }

    /// <summary>
    /// Concrete State B
    /// </summary>
    internal class Sharpen : IFilter
    {
        public void Apply()
        {
            System.Console.WriteLine("Sharpen photo...");
        }
    }

    /// <summary>
    /// Concrete State C
    /// </summary>
    internal class BlackAndWhite : IFilter
    {
        public void Apply()
        {
            System.Console.WriteLine("Remove colour...");
        }
    }
}
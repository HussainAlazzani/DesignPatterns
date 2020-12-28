/// <remarks>
/// 1. Split the object state into intrinsic and extrinsic state
/// 2. Remove the extrinsic state from the object and add it to the calling methods.
/// 3. Create a factory than can reuse existing objects or create and cache new ones.
/// </remarks>

// Code source:


using System.IO;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class FlyweightTest
    {
        public static void Run()
        {
            var webpage = new Webpage();
            webpage.Render();
        }
    }

    /// <summary>
    /// Flyweight
    /// </summary>
    public abstract class BaseMessage
    {
        public abstract void Display(int fontSize, string fontFamily);
    }

    /// <summary>
    /// Concrete flyweight
    /// </summary>
    public class Message : BaseMessage
    {
        // Intrinsic state
        protected string filename;

        public Message(string filename)
        {
            this.filename = filename;
        }

        // Extrinsic state is passed as argument
        public override void Display(int fontSize, string fontFamily)
        {
            string message = File.ReadAllText(@"..\CSharpDesignPatterns\Message\" + filename);

            System.Console.WriteLine(@"<p style=""font-size:{0}px; font-family:{1};"">{2}</p>",
            fontSize, fontFamily, message);
        }
    }

    /// <summary>
    /// Flyweight Factory - uses factory method design pattern
    /// </summary>
    public class MessageFactory
    {
        private IDictionary<string, BaseMessage> flyweights = new Dictionary<string, BaseMessage>();

        public BaseMessage GetFlyweight(string filename)
        {
            BaseMessage flyweight = null;

            // Check if cached shared flyweights
            if (flyweights.ContainsKey(filename))
            {
                flyweight = flyweights[filename] as BaseMessage;
            }
            else
            {
                // Create new flyweight and add it to cache
                flyweight = new Message(filename);
                flyweights.Add(filename, flyweight);
            }

            return flyweight;
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    public class Webpage
    {
        public void Render()
        {
            MessageFactory factory = new MessageFactory();

            BaseMessage message = factory.GetFlyweight("message_1.txt");
            message.Display(12, "Verdana");

            message = factory.GetFlyweight("message_2.txt");
            message.Display(18, "Arial");

            message = factory.GetFlyweight("message_3.txt");
            message.Display(22, "Serif");
        }
    }
}
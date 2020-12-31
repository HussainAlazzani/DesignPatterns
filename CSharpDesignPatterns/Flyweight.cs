/// <remarks>
/// 1. Split the object state into intrinsic and extrinsic state
/// 2. Remove the extrinsic state from the object and add it to the calling methods.
/// 3. Create a factory than can reuse existing objects or create and cache new ones.
/// </remarks>

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
    internal abstract class BaseMessage
    {
        internal abstract void Display(int fontSize, string fontFamily);
    }

    /// <summary>
    /// Concrete flyweight
    /// </summary>
    internal class Message : BaseMessage
    {
        // Intrinsic state
        protected string filename;

        internal Message(string filename)
        {
            this.filename = filename;
        }

        // Extrinsic state is passed as argument
        internal override void Display(int fontSize, string fontFamily)
        {
            string message = File.ReadAllText(@"..\CSharpDesignPatterns\Message\" + filename);

            System.Console.WriteLine(@"<p style=""font-size:{0}px; font-family:{1};"">{2}</p>",
            fontSize, fontFamily, message);
        }
    }

    /// <summary>
    /// Flyweight Factory - uses factory method design pattern
    /// </summary>
    internal class MessageFactory
    {
        private IDictionary<string, BaseMessage> flyweights = new Dictionary<string, BaseMessage>();

        internal BaseMessage GetFlyweight(string filename)
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
    internal class Webpage
    {
        internal void Render()
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
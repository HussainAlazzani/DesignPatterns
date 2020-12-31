using System;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class ProxyTest
    {
        public static void Run()
        {
            ISave msgSaver = new MessageSaverProxy();
            msgSaver.Save("Hello World");
        }
    }

    /// <summary>
    /// Subject
    /// </summary>
    internal interface ISave
    {
        void Save(string message);
    }

    /// <summary>
    /// Proxy
    /// </summary>
    internal class MessageSaverProxy : ISave
    {
        private MessageSaver real = new MessageSaver();

        public void Save(string message)
        {
            string encryptedMassage = Encrypt(message);
            real.Save(encryptedMassage);
        }

        private string Encrypt(string UnencryptedMessage)
        {
            System.Console.WriteLine("Original message: " + UnencryptedMessage);
            char[] c = UnencryptedMessage.ToCharArray();

            // Simple encryption
            for (int i = 0; i < c.Length; i++)
            {
                c[i]++;
            }

            return new String(c);
        }
    }

    /// <summary>
    /// Real Subject
    /// </summary>
    internal class MessageSaver
    {
        internal void Save(string message)
        {
            System.Console.WriteLine("Saving message: " + message);
        }
    }

}
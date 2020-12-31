namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class SingletonTest
    {
        public static void Run()
        {
            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();

            // returns true
            System.Console.WriteLine(s1 == s2);

            // Cannot access constructor because it is private.
            // var s3 = new Singleton();

        }
    }

    /// <summary>
    /// Singleton
    /// </summary>
    internal class Singleton
    {
        private static Singleton instance;
        private Singleton() { }

        internal static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    /// <summary>
    /// Singleton for multithreaded applications
    /// </summary>
    internal class SingletonMultithreaded
    {
        private static SingletonMultithreaded instance;
        private SingletonMultithreaded() { }

        private static readonly object lockObject = new object();

        internal static SingletonMultithreaded GetInstance()
        {
            // This if conditional is needed to prevent threads stumbling
            // over the lock once the instance is ready.
            if (instance == null)
            {
                // The first thread that acquires the lock object will proceed.
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SingletonMultithreaded();
                    }
                }
            }
            return instance;
        }
    }
}
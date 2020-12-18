namespace CSharpDesignPatterns
{
    public class Singleton
    {
        private static Singleton instance;
        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
    public class SingletonMultithreaded
    {
        private static SingletonMultithreaded instance;
        private SingletonMultithreaded() { }

        private static readonly object lockObject = new object();

        public static SingletonMultithreaded GetInstance()
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
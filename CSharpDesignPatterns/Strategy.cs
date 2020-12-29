namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class StrategyTest
    {
        public static void Run()
        {
            FileEncryption encryptor = new FileEncryption(new AES());
            encryptor.Encrypt("my_file.txt");

            encryptor.Encryption = new RSA();
            encryptor.Encrypt("my_second_file.txt");

            encryptor.Encryption = new Blowfish();
            encryptor.Encrypt("my_third_file.txt");
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class FileEncryption
    {
        public FileEncryption(IEncryption encryption)
        {
            Encryption = encryption;
        }

        public IEncryption Encryption { get; set; }

        public void Encrypt(string filename)
        {
            Encryption.Apply(filename);
        }
    }

    /// <summary>
    /// Strategy
    /// </summary>
    public interface IEncryption
    {
        void Apply(string filename);
    }

    /// <summary>
    /// Concrete Strategy A
    /// </summary>
    public class AES : IEncryption
    {
        public void Apply(string filename)
        {
            System.Console.WriteLine("Encrypt file: " + filename);
        }
    }

    /// <summary>
    /// Concrete Strategy B
    /// </summary>
    public class RSA : IEncryption
    {
        public void Apply(string filename)
        {
            System.Console.WriteLine("Encrypt file: " + filename);
        }
    }

    /// <summary>
    /// Concrete Strategy C
    /// </summary>
    public class Blowfish : IEncryption
    {
        public void Apply(string filename)
        {
            System.Console.WriteLine("Encrypt file: " + filename);
        }
    }
}
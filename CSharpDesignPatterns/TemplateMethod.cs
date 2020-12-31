namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class TemplateMethodTest
    {
        public static void Run()
        {   
            UpdateUser update = new UpdateLocalUser();
            update.UpdateUserAddress(1, "Chelsea, London");
            update.UpdateUserAddress(2, "MayFair, London");
        }
    }

    /// <summary>
    /// Abstract class
    /// </summary>
    internal abstract class UpdateUser
    {
        protected abstract bool FindUser(int id);
        protected abstract void UpdateAddress(string address);
        protected abstract void ConfirmUpdate(int id);
        protected abstract void UserNotFound(int id);

        /// <summary>
        /// Template method
        /// </summary>
        internal void UpdateUserAddress(int id, string newAddress)
        {
            bool isFound = FindUser(id);

            if (isFound)
            {
                UpdateAddress(newAddress);
                ConfirmUpdate(id);
            }
            else
            {
                UserNotFound(id);
            }

        }
    }

    /// <summary>
    /// Concrete class A
    /// </summary>
    internal class UpdateLocalUser : UpdateUser
    {
        protected override void ConfirmUpdate(int id)
        {
            System.Console.WriteLine($"User {id} address has been updated.");
        }

        protected override bool FindUser(int id)
        {
            System.Console.WriteLine($"Fetching user {id} from local database");
            return true;
        }

        protected override void UpdateAddress(string address)
        {
            System.Console.WriteLine("Local database updated.");
        }

        protected override void UserNotFound(int id)
        {
            System.Console.WriteLine($"User {id} is not found in the local database.");
        }
    }

    /// <summary>
    /// Concrete class B
    /// </summary>
    internal class UpdateRemoteUser : UpdateUser
    {
        protected override void ConfirmUpdate(int id)
        {
            System.Console.WriteLine($"User {id} address has been updated.");
        }

        protected override bool FindUser(int id)
        {
            System.Console.WriteLine($"Fetching user {id} from remote network server");
            return true;
        }

        protected override void UpdateAddress(string address)
        {
            System.Console.WriteLine("Remote database server updated.");
        }

        protected override void UserNotFound(int id)
        {
            System.Console.WriteLine($"User {id} is not found in the remote database.");
        }
    }
}
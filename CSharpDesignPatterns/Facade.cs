using System;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class FacadeTest
    {
        public static void Run()
        {
            System.Console.Write("Enter account to transfer from: ");
            string accountA = Console.ReadLine();
            System.Console.Write("Enter account to transfer to: ");
            string accountB = Console.ReadLine();
            System.Console.Write("Enter amount: ");

            decimal amount;

            if (Decimal.TryParse(Console.ReadLine(), out amount))
            {
                FinancialServices service = new FinancialServices();
                service.Transfer(accountA, accountB, amount);
            }
        }
    }


    /// <summary>
    /// Facade
    /// </summary>
    public class FinancialServices
    {
        public void Transfer(string from, string to, decimal amount)
        {
            Account accountA = new Account(from);
            Account accountB = new Account(to);

            using (Connection con = new Connection())
            {
                con.Open();

                accountA.Withdraw(amount);
                accountB.Diposite(amount);

                con.Close();
            }

            confirmation confirmation = new confirmation();
            confirmation.Show(accountA, accountB, amount);
        }
    }

    /// <summary>
    /// Subsystem A
    /// </summary>
    internal class Connection : IDisposable
    {
        internal void Open()
        {
            System.Console.WriteLine("Connection open...");
        }

        internal void Close()
        {
            System.Console.WriteLine("Connection closed");
        }

        public void Dispose()
        {
            System.Console.WriteLine("Dispose");
        }
    }

    /// <summary>
    /// Subsystem B
    /// </summary>
    internal class Account
    {
        internal Account(string accountNumber)
        {
            this.AccountNumber = accountNumber;
            this.Balance = 100m;
        }

        internal string AccountNumber { get; }
        internal decimal Balance { get; set; }

        internal void Diposite(decimal amount)
        {
            Balance += amount;
        }

        internal void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }

    /// <summary>
    /// Subsystem C
    /// </summary>
    internal class confirmation
    {
        internal void Show(Account from, Account to, decimal amount)
        {
            System.Console.WriteLine($"£{amount} has been transfered from account number {from.AccountNumber} to {to.AccountNumber} on {DateTime.Now}.");
        }
    }
}
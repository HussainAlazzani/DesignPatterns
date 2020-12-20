namespace CSharpDesignPatterns
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public class BankAccount
    {
        protected IAccount account;

        public BankAccount(IAccount account)
        {
            this.account = account;
        }

        public void Deposite(decimal amount)
        {
            account.Deposite(amount);
        }

        public void Withdraw(decimal amount)
        {
            account.Withdraw(amount);
        }

        public void ShowBalance()
        {
            System.Console.WriteLine(account.Balance);
        }

    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface IAccount
    {
        decimal Balance { get; }
        void Withdraw(decimal amount);
        void Deposite(decimal amount);
    }

    /// <summary>
    /// Concrete Implementor A
    /// </summary>
    public class CurrentAccount : IAccount
    {
        public decimal Balance {get; private set;}

        public void Deposite(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
        
        // other method implementations specific to current accounts
        // ...
    }

    /// <summary>
    /// Concrete Implementor B
    /// </summary>
    public class SavingsAccount : IAccount
    {
        public decimal Balance { get; private set; }

        public void Deposite(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        // other method implementations specific to savings accounts
        // ...
    }
}
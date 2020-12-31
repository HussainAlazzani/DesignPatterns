using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class CommandTest
    {
        public static void Run()
        {
            CurrencyExchange exchange = new CurrencyExchange();

            IExchange buyEuro = new BuyEuro(exchange, 1000m);
            IExchange buyBitcoin = new BuyBitcoin(exchange, 50m, "iskjwno1m3c5$n&nd!k");

            CurrencyExchangeService exchangeService = new CurrencyExchangeService();
            exchangeService.AddOrder(buyEuro);
            exchangeService.AddOrder(buyBitcoin);
            exchangeService.ExecuteOrders();
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    internal interface IExchange
    {
        void Execute();
    }

    /// <summary>
    /// Concrete command A
    /// </summary>
    internal class BuyEuro : IExchange
    {
        private CurrencyExchange exchange;
        private decimal amount;

        internal BuyEuro(CurrencyExchange exchange, decimal amount)
        {
            this.exchange = exchange;
            this.amount = amount;
        }

        public void Execute()
        {
            // Pound-to-Euro exchange rate
            decimal rate = 1.11m;
            exchange.ExchangeFiat("EUR", amount, rate);
        }
    }

    /// <summary>
    /// Concrete command B
    /// </summary>
    internal class BuyBitcoin : IExchange
    {
        private CurrencyExchange exchange;
        private decimal amount;
        private string btcAddress;

        internal BuyBitcoin(CurrencyExchange exchange, decimal amount, string btcAddress)
        {
            this.exchange = exchange;
            this.amount = amount;
            this.btcAddress = btcAddress;
        }

        public void Execute()
        {
            // Pound-to-Bitcoin exchange rate
            decimal rate = 0.00005m;
            exchange.ExchangeCrypto("BTC", amount, rate, btcAddress);
        }
    }


    /// <summary>
    /// Receiver
    /// </summary>
    internal class CurrencyExchange
    {
        internal void ExchangeFiat(string currency, decimal amount, decimal rate)
        {
            decimal newAmount = amount * rate;
            System.Console.WriteLine($"Exchanged {amount} GBP to {newAmount} {currency} at {DateTime.Now}");
        }

        internal void ExchangeCrypto(string currency, decimal amount, decimal rate, string btcAddress)
        {
            decimal newAmount = amount * rate;
            System.Console.WriteLine($"Exchanged {amount} GBP to {newAmount} {currency}. Address {btcAddress} at {DateTime.Now}");
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    internal class CurrencyExchangeService
    {
        private IList<IExchange> orderList = new List<IExchange>();

        internal void AddOrder(IExchange order)
        {
            orderList.Add(order);
        }

        internal void ExecuteOrders()
        {
            foreach (var order in orderList)
            {
                order.Execute();
            }
            orderList.Clear();
        }
    }
}

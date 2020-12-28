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
    public interface IExchange
    {
        void Execute();
    }

    /// <summary>
    /// Concrete command A
    /// </summary>
    public class BuyEuro : IExchange
    {
        private CurrencyExchange exchange;
        private decimal amount;

        public BuyEuro(CurrencyExchange exchange, decimal amount)
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
    public class BuyBitcoin : IExchange
    {
        private CurrencyExchange exchange;
        private decimal amount;
        private string btcAddress;

        public BuyBitcoin(CurrencyExchange exchange, decimal amount, string btcAddress)
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
    public class CurrencyExchange
    {
        public void ExchangeFiat(string currency, decimal amount, decimal rate)
        {
            decimal newAmount = amount * rate;
            System.Console.WriteLine($"Exchanged {amount} GBP to {newAmount} {currency} at {DateTime.Now}");
        }

        public void ExchangeCrypto(string currency, decimal amount, decimal rate, string btcAddress)
        {
            decimal newAmount = amount * rate;
            System.Console.WriteLine($"Exchanged {amount} GBP to {newAmount} {currency}. Address {btcAddress} at {DateTime.Now}");
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class CurrencyExchangeService
    {
        private IList<IExchange> orderList = new List<IExchange>();

        public void AddOrder(IExchange order)
        {
            orderList.Add(order);
        }

        public void ExecuteOrders()
        {
            foreach (var order in orderList)
            {
                order.Execute();
            }
            orderList.Clear();
        }
    }

}





















// using System.Collections.Generic;

// namespace CSharpDesignPatterns
// {
//     /// <summary>
//     /// Client
//     /// </summary>
//     public class CommandTest
//     {
//         public static void Run()
//         {
//             Stock tslStock = new Stock();

//             IOrder buyStock = new BuyStock(tslStock);
//             IOrder sellStock = new SellStock(tslStock);

//             Broker broker = new Broker();
//             broker.TakeOrder(buyStock);
//             broker.TakeOrder(sellStock);
//             broker.PlaceOrders();
//         }
//     }

//     /// <summary>
//     /// Command
//     /// </summary>
//     public interface IOrder
//     {
//         void Execute();
//     }

//     /// <summary>
//     /// Concrete command A
//     /// </summary>
//     public class BuyStock : IOrder
//     {
//         private Stock tslStock;

//         public BuyStock(Stock tslStock)
//         {
//             this.tslStock = tslStock;
//         }

//         public void Execute()
//         {
//             tslStock.Buy();
//         }
//     }

//     /// <summary>
//     /// Concrete command A
//     /// </summary>
//     public class SellStock : IOrder
//     {
//         private Stock tslStock;

//         public SellStock(Stock tslStock)
//         {
//             this.tslStock = tslStock;
//         }

//         public void Execute()
//         {
//             tslStock.Sell();
//         }
//     }

//     /// <summary>
//     /// Receiver
//     /// </summary>
//     public class Stock
//     {
//         private string name = "TSL";
//         private int quantity = 10;

//         public void Buy()
//         {
//             System.Console.WriteLine($"Stock {name}, quantity: {quantity}.");
//         }

//         public void Sell()
//         {
//             System.Console.WriteLine($"Stock {name}, quantity: {quantity}.");
//         }
//     }

//     /// <summary>
//     /// Invoker
//     /// </summary>
//     public class Broker
//     {
//         private IList<IOrder> orderList = new List<IOrder>();

//         public void TakeOrder(IOrder order)
//         {
//             orderList.Add(order);
//         }

//         public void PlaceOrders()
//         {
//             foreach (var order in orderList)
//             {
//                 order.Execute();
//             }
//             orderList.Clear();
//         }
//     }

// }
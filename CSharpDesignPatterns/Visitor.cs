using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class VisitorTest
    {
        public static void Run()
        {
            IList<IService> services = new List<IService>
            {
                new FoodService(),
                new LaundaryService()
            };

            IPaymentType creditCard = new CreditCard();
            foreach (var service in services)
            {
                service.Accept(creditCard);
            }

            IPaymentType debitCard = new DebitCard();
            foreach (var service in services)
            {
                service.Accept(debitCard);
            }

            IPaymentType paypal = new Paypal();
            foreach (var service in services)
            {
                service.Accept(paypal);
            }
        }
    }

    /// <summary>
    /// Element
    /// </summary>
    internal interface IService
    {
        void Accept(IPaymentType paymentType);
    }

    /// <summary>
    /// Concrete element A
    /// </summary>
    internal class FoodService : IService
    {
        public void Accept(IPaymentType paymentType)
        {
            paymentType.VisitFoodService(this);
        }
    }

    /// <summary>
    /// Concrete element B
    /// </summary>
    internal class LaundaryService : IService
    {
        public void Accept(IPaymentType paymentType)
        {
            paymentType.VisitLaundryService(this);
        }
    }

    /// <summary>
    /// Visitor
    /// </summary>
    internal interface IPaymentType
    {
        void VisitFoodService(FoodService food);
        void VisitLaundryService(LaundaryService laundary);
    }

    /// <summary>
    /// Concrete visitor A
    /// </summary>
    internal class CreditCard : IPaymentType
    {
        public void VisitFoodService(FoodService food)
        {
            System.Console.WriteLine("Process credit card payment for food...");
        }

        public void VisitLaundryService(LaundaryService laundary)
        {
            System.Console.WriteLine("Process credit card payment for laundary service...");
        }
    }

    /// <summary>
    /// Concrete visitor B
    /// </summary>
    internal class DebitCard : IPaymentType
    {
        public void VisitFoodService(FoodService food)
        {
            System.Console.WriteLine("Process debit card payment for food...");
        }

        public void VisitLaundryService(LaundaryService laundary)
        {
            System.Console.WriteLine("Process debit card payment for laundary service...");
        }
    }

    /// <summary>
    /// Concrete visitor C
    /// </summary>
    internal class Paypal : IPaymentType
    {
        public void VisitFoodService(FoodService food)
        {
            System.Console.WriteLine("Process paypal payment for food...");
        }

        public void VisitLaundryService(LaundaryService laundary)
        {
            System.Console.WriteLine("Process paypal payment for laundary service...");
        }
    }
}

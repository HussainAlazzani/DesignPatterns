namespace CSharpDesignPatterns
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IInsurance
    {
        decimal GetQuote(Car car);
        Car AddQuote(Car car);
    }

    /// <summary>
    /// Concrete Component
    /// </summary>
    public class BasicInsurance : IInsurance
    {
        public Car AddQuote(Car car)
        {
            decimal quote = GetQuote(car);
            car.Price += quote;

            return car;
        }

        public decimal GetQuote(Car car)
        {
            System.Console.WriteLine($"Serching a basic insurance quote for {car.Make}, {car.Model}, {car.Year}.");

            return 1000m;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class InsuranceDecorator : IInsurance
    {
        protected IInsurance insurance;

        public InsuranceDecorator(IInsurance insurance)
        {
            this.insurance = insurance;
        }

        public Car AddQuote(Car car)
        {
            decimal quote = GetQuote(car);
            car.Price += quote;

            return car;
        }

        public abstract decimal GetQuote(Car car);
    }


    /// <summary>
    /// Concrete decorator A
    /// </summary>
    public class PrivateComprehensive : InsuranceDecorator
    {
        public PrivateComprehensive(IInsurance insurance) : base(insurance)
        { }

        public override decimal GetQuote(Car car)
        {
            decimal basicQuote = insurance.GetQuote(car);
            return basicQuote + 300m;
        }
    }

    /// <summary>
    /// Concrete decorator B
    /// </summary>
    public class CompanyComprehensive : InsuranceDecorator
    {
        public CompanyComprehensive(IInsurance insurance) : base(insurance)
        { }

        public override decimal GetQuote(Car car)
        {
            decimal basicQuote = base.insurance.GetQuote(car);
            return basicQuote + 500m;
        }
    }
}
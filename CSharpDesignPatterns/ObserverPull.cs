using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class ObserverPullTest
    {
        public static void Run()
        {
            var dataSource = new DataSourcePull();
            IObserverPull spreadsheet = new SpreadsheetPull(dataSource);
            IObserverPull piechart = new PieChartPull(dataSource);
            dataSource.AddObserver(spreadsheet);
            dataSource.AddObserver(piechart);

            dataSource.Display();
            dataSource.Data = 12;
            dataSource.RemoveObserver(piechart);
            dataSource.Data = 13;
        }
    }

    /// <summary>
    /// Subject
    /// </summary>
    public abstract class SubjectPull
    {
        protected IList<IObserverPull> observers = new List<IObserverPull>();
        public abstract void AddObserver(IObserverPull observer);
        public abstract void RemoveObserver(IObserverPull observer);

        protected virtual void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    /// <summary>
    /// Concrete subject
    /// </summary>
    public class DataSourcePull : SubjectPull
    {
        private int data;
        public int Data
        {
            get { return data; }
            set
            {
                data = value;
                System.Console.WriteLine("Data is changed...");
                // Used a seperate method for cases when there are more than one 
                // variable. We don't want to repeat this logic for all of them. 
                NotifyObservers();
            }
        }

        public void Display()
        {
            System.Console.WriteLine($"The data is {data}");
        }

        public override void AddObserver(IObserverPull observer)
        {
            observers.Add(observer);
        }

        public override void RemoveObserver(IObserverPull observer)
        {
            observers.Remove(observer);
        }
    }
    /// <summary>
    /// Observer
    /// </summary>
    public interface IObserverPull
    {
        void Update();
    }
    /// <summary>
    /// Concrete Observer A
    /// </summary>
    public class SpreadsheetPull : IObserverPull
    {
        private DataSourcePull dataSource;

        public SpreadsheetPull(DataSourcePull dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Update()
        {
            System.Console.WriteLine($"Spreadsheet data is {dataSource.Data}");
        }
    }
    /// <summary>
    /// Concrete Observer B.
    /// Better to create a chart base class, then PieChart inherits it.
    /// </summary>
    public class PieChartPull : IObserverPull
    {
        private DataSourcePull dataSource;

        public PieChartPull(DataSourcePull dataSource)
        {
            this.dataSource = dataSource;
        }
        public void Update()
        {
            System.Console.WriteLine($"PieChart data is {dataSource.Data}");
        }
    }

}
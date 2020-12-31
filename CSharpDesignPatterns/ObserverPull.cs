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
    internal abstract class SubjectPull
    {
        protected IList<IObserverPull> observers = new List<IObserverPull>();
        internal abstract void AddObserver(IObserverPull observer);
        internal abstract void RemoveObserver(IObserverPull observer);

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
    internal class DataSourcePull : SubjectPull
    {
        private int data;
        internal int Data
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

        internal void Display()
        {
            System.Console.WriteLine($"The data is {data}");
        }

        internal override void AddObserver(IObserverPull observer)
        {
            observers.Add(observer);
        }

        internal override void RemoveObserver(IObserverPull observer)
        {
            observers.Remove(observer);
        }
    }
    /// <summary>
    /// Observer
    /// </summary>
    internal interface IObserverPull
    {
        void Update();
    }
    /// <summary>
    /// Concrete Observer A
    /// </summary>
    internal class SpreadsheetPull : IObserverPull
    {
        private DataSourcePull dataSource;

        internal SpreadsheetPull(DataSourcePull dataSource)
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
    internal class PieChartPull : IObserverPull
    {
        private DataSourcePull dataSource;

        internal PieChartPull(DataSourcePull dataSource)
        {
            this.dataSource = dataSource;
        }
        public void Update()
        {
            System.Console.WriteLine($"PieChart data is {dataSource.Data}");
        }
    }
}
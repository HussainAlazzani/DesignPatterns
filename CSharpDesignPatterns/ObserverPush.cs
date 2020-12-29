using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class ObserverPushTest
    {
        public static void Run()
        {
            var dataSource = new DataSourcePush();
            IObserverPush spreadsheet = new Spreadsheet();
            IObserverPush piechart = new PieChart();
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
    public abstract class SubjectPush
    {
        protected IList<IObserverPush> observers = new List<IObserverPush>();
        public abstract void AddObserver(IObserverPush observer);
        public abstract void RemoveObserver(IObserverPush observer);

        // Keeping it simple by passing int instead of something more generic.
        protected virtual void NotifyObservers(int data)
        {
            foreach (var observer in observers)
            {
                observer.Update(data);
            }
        }
    }

    /// <summary>
    /// Concrete subject
    /// </summary>
    public class DataSourcePush : SubjectPush
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
                NotifyObservers(data);
            }
        }

        public void Display()
        {
            System.Console.WriteLine($"The data is {data}");
        }

        public override void AddObserver(IObserverPush observer)
        {
            observers.Add(observer);
        }

        public override void RemoveObserver(IObserverPush observer)
        {
            observers.Remove(observer);
        }
    }
    /// <summary>
    /// Observer
    /// </summary>
    public interface IObserverPush
    {
        void Update(int data);
    }
    /// <summary>
    /// Concrete Observer A
    /// </summary>
    public class Spreadsheet : IObserverPush
    {
        public void Update(int data)
        {
            System.Console.WriteLine($"Spreadsheet data is {data}");
        }
    }
    /// <summary>
    /// Concrete Observer B.
    /// Better to create a chart base class, then PieChart inherits it.
    /// </summary>
    public class PieChart : IObserverPush
    {
        public void Update(int data)
        {
            System.Console.WriteLine($"PieChart data is {data}");
        }
    }
}
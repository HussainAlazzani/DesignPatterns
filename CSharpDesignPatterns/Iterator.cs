using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class IteratorTest
    {
        public static void Run()
        {
            ReadingList readingList = new ReadingList();
            readingList.Add("C# For Professionals");
            readingList.Add("Sapiens, A Brief History Of Humankind");
            readingList.Add("Head First Design Patterns");
            readingList.Add("Thinking, Fast and Slow");
            readingList.Add("A Random Walk Down Wall Street");

            IIterator iterator = readingList.CreateIterator();

            while (iterator.HasNext())
            {
                System.Console.WriteLine(iterator.Current());
                iterator.Next();
            }
        }
    }

    /// <summary>
    /// Aggregate interface
    /// </summary>
    internal interface IAggregate
    {
        IIterator CreateIterator();
    }

    /// <summary>
    /// Iterator interface
    /// </summary>
    internal interface IIterator
    {
        string Current();
        void Next();
        bool HasNext();
        void Reset();
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    internal class ReadingList : IAggregate
    {
        private IList<string> readingList = new List<string>();

        public IIterator CreateIterator()
        {
            return new MyIterator(this);
        }

        internal int Count => readingList.Count;

        internal void Add(string bookTitle)
        {
            readingList.Add(bookTitle);
        }

        internal string this[int index]
        {
            get { return readingList[index]; }
            set { readingList.Insert(index, value); }
        }
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    internal class MyIterator : IIterator
    {
        private readonly ReadingList readingList;
        private int index;

        internal MyIterator(ReadingList readingList)
        {
            this.readingList = readingList;
        }

        public string Current()
        {
            return readingList[index];
        }

        public bool HasNext()
        {
            if (index < readingList.Count)
                return true;

            return false;
        }

        public void Next()
        {
            index++;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
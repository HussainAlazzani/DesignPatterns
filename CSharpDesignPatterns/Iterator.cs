using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Aggregate interface
    /// </summary>
    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    /// <summary>
    /// Iterator interface
    /// </summary>
    public interface IIterator
    {
        string Current();
        void Next();
        bool HasNext();
        void Reset();
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    public class ReadingList : IAggregate
    {
        private IList<string> readingList = new List<string>();

        public IIterator CreateIterator()
        {
            return new MyIterator(this);
        }

        public int Count => readingList.Count;

        public void Add(string bookTitle)
        {
            readingList.Add(bookTitle);
        }

        public string this[int index]
        {
            get { return readingList[index]; }
            set { readingList.Insert(index, value); }
        }
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    public class MyIterator : IIterator
    {
        private readonly ReadingList readingList;
        private int index;

        public MyIterator(ReadingList readingList)
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
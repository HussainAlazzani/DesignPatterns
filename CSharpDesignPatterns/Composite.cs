using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class CompositeTest
    {
        public static void Run()
        {
            IFamilyMember jason = new Child("Jason", new DateTime(2001, 12, 4));
            IFamilyMember natalie = new Child("Natalie", new DateTime(2005, 5, 23));
            IFamilyMember kumar = new Child("Kumar", new DateTime(2002, 1, 18));

            IFamilyMember peter = new Parent("Peter", new DateTime(1970, 5, 11));
            peter.AddChild(jason);
            peter.AddChild(natalie);

            IFamilyMember ann = new Parent("Ann", new DateTime(1968, 11, 13));
            ann.AddChild(kumar);

            IFamilyMember margaret = new Parent("Margaret", new DateTime(1940, 3, 02));
            margaret.AddChild(peter);
            margaret.AddChild(ann);

            // Display Margaret's children and grandchildren
            margaret.GetDetails();
            System.Console.WriteLine();
            // Display Jason's details
            jason.GetDetails();
        }
    }

    /// <summary>
    /// Component 
    /// </summary>
    internal interface IFamilyMember
    {
        void AddChild(IFamilyMember member);
        void GetDetails();
    }

    /// <summary>
    /// Composite
    /// </summary>
    internal class Parent : IFamilyMember
    {
        // Store children of the parent member.
        private IList<IFamilyMember> children;

        internal Parent(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            children = new List<IFamilyMember>();
        }

        internal string Name { get; set; }
        internal DateTime DateOfBirth { get; set; }

        public void AddChild(IFamilyMember member)
        {
            children.Add(member);
        }

        public void GetDetails()
        {
            System.Console.WriteLine($"{Name}, DoB: {DateOfBirth}");

            // This enables looping through each child in the family tree.
            foreach (var child in children)
            {
                child.GetDetails();
            }
        }
    }

    /// <summary>
    /// Leaf
    /// </summary>
    internal class Child : IFamilyMember
    {
        internal Child(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        internal string Name { get; set; }
        internal DateTime DateOfBirth { get; set; }

        public void AddChild(IFamilyMember member)
        {
            throw new Exception("Error: This family member cannot have children");
        }

        public void GetDetails()
        {
            System.Console.WriteLine($"{Name}, DoB: {DateOfBirth}");
        }
    }
}
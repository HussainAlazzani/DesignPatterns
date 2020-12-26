using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Component 
    /// </summary>
    public interface IFamilyMember
    {
        void AddChild(IFamilyMember member);
        void GetDetails();
    }

    /// <summary>
    /// Composite
    /// </summary>
    public class Parent : IFamilyMember
    {
        // Store children of the parent member.
        private IList<IFamilyMember> children;

        public Parent(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            children = new List<IFamilyMember>();
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

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
    public class Child : IFamilyMember
    {
        public Child(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

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
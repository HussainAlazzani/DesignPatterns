// Source: https://www.dofactory.com/net/mediator-design-pattern
// with some modifications

using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class MediatorTest
    {
        public static void Run()
        {
            IChatroom chatroom = new Chatroom();

            Member Jaspal = new Londoner("Jaspal");
            Member Rebecca = new Bromi("Rebecca");
            Member Keith = new Londoner("Keith");
            Member Damien = new Bromi("Damien");
            Member Kasha = new Londoner("Kasha");
            Member Scot = new Bromi("Scot");

            chatroom.Register(Jaspal);
            chatroom.Register(Rebecca);
            chatroom.Register(Keith);
            chatroom.Register(Damien);
            chatroom.Register(Kasha);
            chatroom.Register(Scot);

            Kasha.Send("Rebecca", "Hello Rebecca");
            Jaspal.Send("Damien", "Did you get round to do the work?");
            Rebecca.Send("Kasha", "O Hello Kasha");
            Damien.Send("Scot", "Jaspal is asking about the work.");
        }
    }

    /// <summary>
    /// Mediator
    /// </summary>
    internal interface IChatroom
    {
        void Register(Member member);
        void Send(string from, string to, string message);
    }

    /// <summary>
    /// Concrete mediator
    /// </summary>
    internal class Chatroom : IChatroom
    {
        private Dictionary<string, Member> members = new Dictionary<string, Member>();

        public void Register(Member member)
        {
            if (!members.ContainsValue(member))
            {
                members[member.Name] = member;
            }
            member.Chatroom = this;
        }

        public void Send(string from, string to, string message)
        {
            Member member = members[to];
            if (member != null)
            {
                member.Received(from, message);
            }
        }
    }

    /// <summary>
    /// Colleague
    /// </summary>
    internal class Member
    {
        internal Member(string name)
        {
            Name = name;
        }

        internal string Name { get; }
        internal IChatroom Chatroom { get; set; }

        internal void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        internal virtual void Received(string from, string message)
        {
            System.Console.WriteLine($"From {from} to {Name}: {message}");
        }
    }

    /// <summary>
    /// Concrete Colleague A
    /// </summary>
    internal class Londoner : Member
    {
        internal Londoner(string name) : base(name)
        { }

        internal override void Received(string from, string message)
        {
            System.Console.Write("To a Londoner: ");
            base.Received(from, message);
        }
    }

    /// <summary>
    /// Concrete Colleague B
    /// </summary>
    internal class Bromi : Member
    {
        internal Bromi(string name) : base(name)
        { }

        internal override void Received(string from, string message)
        {
            System.Console.Write("To a Bromi: ");
            base.Received(from, message);
        }
    }
}

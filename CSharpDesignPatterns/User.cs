namespace CSharpDesignPatterns
{
   internal class User
    {
       internal int Id { get; }
       internal string Name { get; set; }
       internal string Address { get; set; }

       internal User(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = Address;
        }
    }
}
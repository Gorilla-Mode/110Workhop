using System.Globalization;

namespace Eksempler;

enum MenuOption
{
    Exit,   //0
    Add,    //1
    Remove, //2
    List    //3
}

class Person
{
    public string Name { get; set; }
    
    public Person(string name)
    {
        if (name.Contains("Walter", StringComparison.InvariantCultureIgnoreCase))
            throw new ArgumentException("He's the devil", nameof(name));
        
        Name = name;
    }
}

static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(MenuOption.Exit);     // -> Exit
        Console.WriteLine((int)MenuOption.Add); // -> 1

        if (!Enum.TryParse(Console.ReadLine(), out MenuOption choice))
            return; 

        switch (choice)
        {
            case MenuOption.Exit:   Console.WriteLine("Exiting...");     break;
            case MenuOption.Add:    Console.WriteLine("Adding...");      break;
            case MenuOption.Remove: Console.WriteLine("Removing...");    break;
            case MenuOption.List:   Console.WriteLine("Listing...");     break;
            default:                Console.WriteLine("Invalid choice"); break;
        }

        Console.WriteLine("Enter name: ");
        var name = Console.ReadLine() ?? string.Empty;
        
        var person = new Person(name);

        Console.WriteLine("Todo List\n 1. Add task\n 2. Select task\n 3. List Items\n 0. Exit");
        var input = Console.ReadLine() ?? string.Empty;

        switch (input)
        {
            case "1":
                Console.WriteLine("Adding...");
                break;
            case "2 ":
                Console.WriteLine("Selecting...");
                break;
            case "\u0033":
                Console.WriteLine("Listing...");
                break;
            case "O":
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
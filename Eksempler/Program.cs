namespace Eksempler;

enum MenuOption
{
    Exit,   //0
    Add,    //1
    Remove, //2
    List    //3
}

static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(MenuOption.Exit);     // -> Exit
        Console.WriteLine((int)MenuOption.Add); // -> 1

        Enum.TryParse(Console.ReadLine(), out MenuOption choice);

        switch (choice)
        {
            case MenuOption.Exit:   Console.WriteLine("Exiting...");     break;
            case MenuOption.Add:    Console.WriteLine("Adding...");      break;
            case MenuOption.Remove: Console.WriteLine("Removing...");    break;
            case MenuOption.List:   Console.WriteLine("Listing...");     break;
            default:                Console.WriteLine("Invalid choice"); break;
        }
    }
}
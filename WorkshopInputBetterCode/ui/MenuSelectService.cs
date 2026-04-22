using WorkshopInputBetterCode.enums;
using WorkshopInputBetterCode.interfaces;
using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.ui;

public class MenuSelectService(ITodoService todoService) : IMenuSelectService
{
    public void Run(ref bool run, Todo selected)
    {
        try
        {
            Console.Clear();
            Console.WriteLine($"Selected task: {selected.Name}\n 1. Mark as done\n 2. Read details\n 3. Delete task\n 0. Exit\n");
            Console.Write("Enter choice: ");

            if (!Enum.TryParse(Console.ReadLine(), out MenuSelectedItem input))
            {
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                return;
            }

            switch (input)
            {
                case MenuSelectedItem.MarkDone: MarkDone(selected);         break;
                case MenuSelectedItem.Read:     Read(selected);             break;
                case MenuSelectedItem.Delete:   Delete(selected);           break;
                case MenuSelectedItem.Exit:     run = false;                return;                             
                default: 
                    Console.WriteLine("Invalid choice"); Console.ReadKey(); break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
    }

    public void Delete(Todo selected)
    {
        Console.Clear();
        todoService.Remove(selected);
        Console.WriteLine($"Task '{selected.Name}' deleted");
        Console.ReadKey();
    }

    public void MarkDone(Todo selected)
    {
        Console.Clear();
        todoService.MarkDone(selected);
        Console.WriteLine($"Task '{selected.Name}' marked as done");
        Console.ReadKey();
    }

    public void Read(Todo selected)
    {
        Console.Clear();
        Console.WriteLine(selected.ToString());
        Console.ReadKey();
    }
}
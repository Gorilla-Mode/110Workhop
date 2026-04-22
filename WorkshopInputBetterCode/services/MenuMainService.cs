using WorkshopInputBetterCode.db;
using WorkshopInputBetterCode.enums;
using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.services;

public static class MenuMainService 
{
    public static void Run()
    {
        for (bool run = true; run;)
        {
            Console.Clear();
            Console.WriteLine("Todo List\n 1. Add task\n 2. Select task\n 3. List Items\n 4. Exit\n");

            if (!Enum.TryParse(Console.ReadLine(), out MenuMain input))
            {
                Console.WriteLine("Invalid choice");
                Console.ReadLine();
                continue;
            }

            switch (input)
            {
                case MenuMain.AddTask: AddTask();                           break;
                case MenuMain.Exit:    run = false;                         break;
                default:               Console.WriteLine("Invalid choice"); break;
            }
            
        }
    }
    
    private static void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Enter task name:");
        string name = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Enter task description:");
        string description = Console.ReadLine() ?? string.Empty;

        try
        {
            Database.Add(new Todo(name, description));
            Console.WriteLine("Task added");
            Console.ReadLine();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
            Run();
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"Validation failed: {e.InnerExceptions.Count} error(s)");
            foreach (var exception in e.InnerExceptions)
            {
                Console.WriteLine($"\t{exception.Message}");
            }
            
            Console.ReadLine();
            Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
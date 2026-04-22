using WorkshopInputBetterCode.enums;
using WorkshopInputBetterCode.interfaces;

namespace WorkshopInputBetterCode.ui;

public class MenuMainService(ITodoService todoService, IMenuSelectService selectService) : IMenuMainService
{
    public void Run()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Todo List\n 1. Add task\n 2. Select task\n 3. List Items\n 0. Exit\n");
            Console.Write("Enter choice: ");

            if (!Enum.TryParse(Console.ReadLine(), out MenuMain input))
            {
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                return;
            }

            switch (input)
            {
                case MenuMain.AddTask:    AddTask();                        break;
                case MenuMain.SelectTask: SelectTask();                     break;
                case MenuMain.ListTasks:  ListTasks();                      break;
                case MenuMain.Exit:       Environment.Exit(0);              break;
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

    public void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Enter task name:");
        string name = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Enter task description:");
        string description = Console.ReadLine() ?? string.Empty;
        todoService.Add(name, description);
        Console.ReadKey();
    }

    public void SelectTask()
    {
        Console.Clear();
        Console.WriteLine("Enter task id/name:");
        string query = Console.ReadLine() ?? string.Empty;
        
        var result = todoService.Select(query);
        if (result == null)
        {
            Console.WriteLine("Task not found");
            Console.ReadKey();
            return;
        }

        bool run = true;
        while (run)
        {
            selectService.Run(ref run, result);
        }
    }

    public void ListTasks()
    {
        Console.Clear();
        Console.WriteLine("List of tasks:");
        todoService.List();
        Console.ReadKey();
    }
}
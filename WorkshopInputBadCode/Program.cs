using WorkshopInput;

List<Todo> tasks = new List<Todo>();

bool run = true;
while (run)
{
    Console.Clear();
    Console.WriteLine("Todo List\n 1. Add task\n 2. Select task\n 3. List Items\n 4. Exit");
    
    string choice = Console.ReadLine() ?? string.Empty;
    
    switch (choice)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Enter task name:");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter task description:");
            string description = Console.ReadLine() ?? string.Empty;

            tasks.Add(new Todo(name, description));
            Console.WriteLine("Task added");
            Console.ReadLine();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Enter task id/name:");
            string query = Console.ReadLine() ?? string.Empty;
            
            var selectedTodo = tasks.FirstOrDefault(t => t.Id.ToString() == query || t.Name.Contains(query));

            if (selectedTodo == null)
            {
                Console.WriteLine("Task not found");
                break;
            }

            bool selectedRun = true;
            while (selectedRun)
            {
                Console.Clear();
                Console.WriteLine($"Selected: {selectedTodo.Name}\n1. Mark as done\n2. Read\n3. Delete\n4. Exit");

                string selectedChoice = Console.ReadLine() ?? string.Empty;

                switch (selectedChoice)
                {
                    case "1":
                        Console.Clear();
                        selectedTodo.Done = true;
                        Console.WriteLine("Marked as done");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"Id: {selectedTodo.Id}\nName: {selectedTodo.Name}\nDescription:" +
                                          $" {selectedTodo.Description}\nDone: {selectedTodo.Done}");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        tasks.Remove(selectedTodo);
                        Console.WriteLine("Task deleted");
                        Console.ReadLine();
                        break;
                    case "4":
                        selectedRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice");
                        Console.ReadLine();
                        break;
                        
                }
            }
            Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id: {task.Id}\nName: {task.Name}\nDescription: {task.Description}\n" +
                                 $"Done: {task.Done}\n\n");
            }
            Console.ReadLine();
            break;
        case "4":
            Console.Clear();
            run = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice");
            Console.ReadLine();
            break;
    }
}
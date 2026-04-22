using WorkshopInputBetterCode.db;
using WorkshopInputBetterCode.interfaces;
using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.services;

public class TodoService : ITodoService
{
    public void Add(string name, string description)
    {
        try
        {
            Database.Add(new Todo(name, description));
            Console.WriteLine("Task added");
        }
        catch (AggregateException e)
        {
            var messages = string.Join("\n\t", e.InnerExceptions.Select(x => x.Message));
            throw new InvalidOperationException($"Failed to add task:\n\t{messages}", e);
        }
        catch (Exception e)
        {
           throw new InvalidOperationException($"Failed to add task:\n\t{e.Message}", e);
        }
    }

    public void List()
    {
        try
        {
            var tasks = Database.Get();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
        catch (AggregateException e)
        {
            var messages = string.Join("\n\t", e.InnerExceptions.Select(x => x.Message));
            throw new InvalidOperationException($"Failed to add task:\n\t{messages}", e);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to add task:\n\t{e.Message}", e);
        }
    }

    public Todo? Select(string query)
    {
        var tasks = Database.Get();
        
        var selectedTodo = tasks.FirstOrDefault(t => t.Id.ToString() == query || t.Name.Contains(query));
        
        return selectedTodo;
    }

    public void Remove(Todo selected)
    {
        try
        {
            Database.Remove(selected);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to remove item:\n\t{e.Message}", e);
        }
    }

    public void MarkDone(Todo selected)
    {
        if (selected.Done)
        {
            throw new InvalidOperationException("Item is already marked as done");
        }
        
        try
        {
            selected.Done = true;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to mark item as done:\n\t{e.Message}", e);
        }
    }
}
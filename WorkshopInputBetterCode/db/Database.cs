using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.db;

public static class Database
{
    private static readonly List<Todo> Todos = new();

    public static void Add(Todo item)
    {
        var exceptions = new List<Exception>();
        
        if (Todos.Exists(x => x.Id == item.Id))
            exceptions.Add(new ArgumentException("Id already in use", nameof(item))); 
        if (Todos.Exists(x => x.Name == item.Name))
            exceptions.Add(new ArgumentException("Name already in use", nameof(item)));
        if (exceptions.Any())
            throw new AggregateException("Validation Failed", exceptions);
        
        Todos.Add(item);
    }
    
    public static void Remove(Todo item)
    {
        if (!Todos.Contains(item))
            throw new ArgumentException("Item does not exist in database", nameof(item));
        
        Todos.Remove(item);
    }
    
    public static Todo? Get(string query)
    {
        return Todos.Find(x => x.Id.ToString() == query ||
                                x.Name.Equals(query, StringComparison.InvariantCultureIgnoreCase));
    }

    public static IReadOnlyList<Todo> Get()
    {
        return Todos.AsReadOnly();
    }
}
using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.interfaces;

public interface ITodoService
{
    /// <summary>
    /// Adds a new task item with the specified name and description.
    /// </summary>
    /// <param name="name">The name of the task item.</param>
    /// <param name="description">The description of the task item.</param>
    public void Add(string name, string description);

    public void List();
    public Todo? Select(string query);
    public void Remove(Todo selected);
    public void MarkDone(Todo selected);
}
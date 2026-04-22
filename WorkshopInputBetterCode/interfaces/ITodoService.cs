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

    /// <summary>
    /// Displays the list of all task items currently stored in the database.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an error occurs during the retrieval or display of task items.
    /// </exception>
    public void List();

    /// <summary>
    /// Retrieves a task item that matches the specified query from the database.
    /// </summary>
    /// <param name="query">The search query used to find the task. This can be the task's ID or name.</param>
    /// <returns>The task item that matches the query or null if no match is found.</returns>
    public Todo? Select(string query);

    /// <summary>
    /// Removes the specified task item from the database.
    /// </summary>
    /// <param name="selected">The task item to be removed.</param>
    public void Remove(Todo selected);

    /// <summary>
    /// Marks the specified task item as done, indicating its completion.
    /// </summary>
    /// <param name="selected">The task item to be marked as done.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the task item is already marked as done, or if an error occurs while attempting to mark it as done.
    /// </exception>
    public void MarkDone(Todo selected);
}
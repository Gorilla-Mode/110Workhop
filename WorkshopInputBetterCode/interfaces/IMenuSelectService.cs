using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.interfaces;

public interface IMenuSelectService
{
    /// <summary>
    /// Executes menu functionality for a specific selected task and processes user input.
    /// </summary>
    /// <param name="run">A pointer parameter that determines whether the menu loop should continue running.</param>
    /// <param name="selected">The selected task item on which the menu operations will be performed.</param>
    public void Run(ref bool run, Todo selected);

    /// <summary>
    /// Deletes the specified task item from the menu and triggers its removal.
    /// </summary>
    /// <param name="selected">The task item to be deleted.</param>
    public void Delete(Todo selected);

    /// <summary>
    /// Marks the specified task item as completed and updates its status accordingly.
    /// </summary>
    /// <param name="selected">The task item to be marked as completed.</param>
    public void MarkDone(Todo selected);
    
    /// <summary>
    /// Displays the details of the specified task item.
    /// </summary>
    /// <param name="selected">The task item whose details will be displayed.</param>
    public void Read(Todo selected);
}
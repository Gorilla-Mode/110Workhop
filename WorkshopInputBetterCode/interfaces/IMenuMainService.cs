using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.interfaces;

public interface IMenuMainService
{
    /// <summary>
    /// Executes the main menu functionality
    /// </summary>
    public void Run(ref bool run);

    /// <summary>
    /// Adds a new task by prompting the user for its name and description.
    /// </summary>
    public void AddTask();

    /// <summary>
    /// Allows the user to select a specific task based on an identifier or name
    /// and provides a menu for performing operations on that task.
    /// </summary>
    public void SelectTask();

    /// <summary>
    /// Displays a list of all tasks by invoking the corresponding service method.
    /// This method clears the console, outputs a header, lists all tasks, and allows the
    /// user to view the data before proceeding.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an error occurs during the retrieval of task data from the service.
    /// </exception>
    public void ListTasks();
}
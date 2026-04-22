using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.interfaces;

public interface IMenuMainService
{
    public void Run();
    public void AddTask();
    public void SelectTask();
    public void ListTasks();
}
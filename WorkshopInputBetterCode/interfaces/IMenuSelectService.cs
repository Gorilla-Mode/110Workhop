using WorkshopInputBetterCode.models;

namespace WorkshopInputBetterCode.interfaces;

public interface IMenuSelectService
{
    public void Run(ref bool run, Todo selected);
    public void Delete(Todo selected);
    public void MarkDone(Todo selected);
    public void Read(Todo selected);
}
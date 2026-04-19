namespace WorkshopInput;

public sealed record Todo(string Name, string Description)
{
    public uint Id { get; init; } = (uint)Random.Shared.Next();
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    public bool Done { get; set; }
}
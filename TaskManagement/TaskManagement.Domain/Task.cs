namespace TaskManagement.Domain;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Status Status { get; set; }
    public string? AssignedTo { get; set; }
}

public class ToDoTask
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public ToDoStatus Status { get; set; } = ToDoStatus.ToDo;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

}
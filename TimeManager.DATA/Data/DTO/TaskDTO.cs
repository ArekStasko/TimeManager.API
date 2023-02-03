namespace TimeManager.DATA.Data.DTO;

public class TaskDTO
{
    public Guid? Id { get; set; } = null;
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateCompleted { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }
    public Guid UserId { get; set; }
    public bool Completed { get; set; } = false;
}
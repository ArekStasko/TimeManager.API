namespace TimeManager.DATA.Data.DTO;

public class TaskSetDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public List<TaskDate> TaskOccurencies { get; set; }
}
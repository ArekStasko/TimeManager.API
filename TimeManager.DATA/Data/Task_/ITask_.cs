namespace TimeManager.DATA.Data
{
    public interface ITask_
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Type { get; set; }
        DateTime DateAdded { get; set; }
        DateTime DateCompleted { get; set; }
        DateTime Deadline { get; set; }
        int Priority { get; set; }
        Guid UserId { get; set; }
        bool Completed { get; set; }
    }
}

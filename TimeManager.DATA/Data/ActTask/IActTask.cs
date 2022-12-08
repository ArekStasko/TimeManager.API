namespace TimeManager.DATA.Data
{
    public interface IActTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
    }
}

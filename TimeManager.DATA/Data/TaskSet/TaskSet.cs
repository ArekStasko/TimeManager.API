using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public class TaskSet : ITaskSet
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<DateTime> TaskOccurencies { get; set; }
        public Task_ actTask { get; set; }
    }
}

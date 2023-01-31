using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.DATA.Data
{
    public class TaskSet : ITaskSet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public Task_ Task { get; set; }
    }

    public class TaskDate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}

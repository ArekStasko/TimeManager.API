using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.DATA.Data
{
    public class Task_ : ITask_
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
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
}

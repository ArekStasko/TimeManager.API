using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeManager.DATA.Data
{
    public interface ITaskSet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
    }
}

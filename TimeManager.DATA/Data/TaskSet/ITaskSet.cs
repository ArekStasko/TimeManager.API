using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public interface ITaskSet
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<TaskDate> TaskOccurencies { get; set; }
        public Task_ Task { get; set; }
    }
}

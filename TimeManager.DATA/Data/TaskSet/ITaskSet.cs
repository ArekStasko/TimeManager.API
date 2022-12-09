using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public interface ITaskSet
    {
        [Key]
        public int Id { get; set; }
        public List<DateTime> TaskOccurencies { get; set; }
        public Task_ actTask { get; set; }
    }
}

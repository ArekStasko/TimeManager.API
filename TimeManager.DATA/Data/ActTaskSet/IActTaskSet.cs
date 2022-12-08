using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public interface IActTaskSet
    {
        [Key]
        public int Id { get; set; }
        public List<DateTime> TaskOccurencies { get; set; }
        public ActTask actTask { get; set; }
    }
}

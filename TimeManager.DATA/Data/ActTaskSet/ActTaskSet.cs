using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public class ActTaskSet : IActTaskSet
    {
        [Key]
        public int Id { get; set; }
        public List<DateTime> TaskOccurencies { get; set; }
        public ActTask actTask { get; set; }
    }
}

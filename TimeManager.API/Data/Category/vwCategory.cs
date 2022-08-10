using System.ComponentModel.DataAnnotations;

namespace TimeManager.API.Data
{
    public class vwCategory : ICategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivitiesNum { get; set; }
    }
}

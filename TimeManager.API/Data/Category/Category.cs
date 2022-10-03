using System.ComponentModel.DataAnnotations;

namespace TimeManager.API.Data
{
    public class Category : ICategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivitiesNum { get; set; }
        public int AvgProductivity { get; set; }
    }
}

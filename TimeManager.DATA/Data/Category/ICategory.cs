namespace TimeManager.DATA.Data
{
    public interface ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivitiesNum { get; set; }
        public int AvgProductivity { get; set; }
    }
}

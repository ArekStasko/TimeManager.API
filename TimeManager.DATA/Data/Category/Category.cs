﻿using System.ComponentModel.DataAnnotations;

namespace TimeManager.DATA.Data
{
    public class Category : ICategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivitiesNum { get; set; }
        public int AvgProductivity { get; set; }
        public int UserId { get; set; }
    }
}

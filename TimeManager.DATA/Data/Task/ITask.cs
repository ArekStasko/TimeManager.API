﻿namespace TimeManager.DATA.Data
{
    public interface ITask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }    
        public int Priority { get; set; }
        public List<DateTime> dateTimes { get; set; }
    }
}

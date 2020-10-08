using System;

namespace F4TestProject.Domain.Models
{
    public class ActionItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImageLink { get; set; }
    }
}

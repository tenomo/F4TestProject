using System;
using System.Collections.Generic;
using System.Linq;

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
        public double Price { get; set; }
        public int CountOfSeats { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public int CountOfFreeSeats => CountOfSeats - Orders?.Select(order => order.Tickets).Sum(s => s) ?? 0;
    }
}

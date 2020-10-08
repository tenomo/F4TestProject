using System;
using System.Collections.Generic;
using System.Linq;

namespace F4TestProject.Domain.Models
{
    public class ActionItem
    {
        public ActionItem()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImageLink { get; set; }
        public double Price { get; set; }
        public int CountOfSeats { get; set; }
        public IReadOnlyCollection<Order> Orders { get; set; }
        public int CountOfFreeSeats => CountOfSeats - Orders.Select(order => order.Tickets).Sum(s => s);
    }
}

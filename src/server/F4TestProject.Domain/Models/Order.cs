using System;

namespace F4TestProject.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public ActionItem ActionItem { get; set; }
        public short Tickets { get; set; }
        public double TotalPrice => ActionItem.Price * Tickets;
    }
}

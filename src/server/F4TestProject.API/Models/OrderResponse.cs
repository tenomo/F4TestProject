using System;

namespace F4TestProject.API.Models
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public ActionItemResponse ActionItem { get; set; }
        public short Tickets { get; set; }
        public double TotalPrice => ActionItem.Price * Tickets;
    }
}

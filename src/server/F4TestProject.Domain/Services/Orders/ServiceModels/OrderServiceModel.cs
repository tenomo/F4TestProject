using F4TestProject.Domain.Models;
using System;

namespace F4TestProject.Domain.Services.Orders.ServiceModels
{
    public class OrderServiceModel
    {
        public Guid ActionItemId { get; set; }
        public User Customer { get; set; }
        public short Tickets { get; set; }
    }
}

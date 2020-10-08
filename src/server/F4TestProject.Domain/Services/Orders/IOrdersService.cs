using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Orders.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services.Orders
{
    public interface IOrdersService
    {
        Task Create(OrderServiceModel order);
        Task<IEnumerable<Order>> GetByCustomerId(Guid customerId);
    }
}

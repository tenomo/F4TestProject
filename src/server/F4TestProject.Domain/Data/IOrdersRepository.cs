using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Data
{
    public interface IOrdersRepository : IRepository
    {
        void Create(Order order);
        Task<IEnumerable<Order>> GetByCustomerId(Guid customerId);
    }
}

using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F4TestProject.Persistence
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Task SaveChanges()
        {
            return _applicationDbContext.SaveChangesAsync();
        }

        public void Create(Order order)
        {
            _applicationDbContext.Orders.Add(order);
        }

        public Task<IEnumerable<Order>> GetByCustomerId(Guid customerId)
        {
            return new TaskFactory().ContinueWhenAll(new Task[] { _applicationDbContext.Orders.AsNoTracking().ToListAsync() },
                tasks => tasks[0] as IEnumerable<Order>);
        }
    }
}

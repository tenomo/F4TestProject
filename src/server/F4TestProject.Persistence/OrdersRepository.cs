using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F4TestProject.Persistence
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrdersRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

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
            return _applicationDbContext.Orders.
                  Include(order => order.Customer).Include(order => order.ActionItem)
                  .AsNoTracking().ToListAsync().ContinueWith(task => task.Result.ToList() as IEnumerable<Order>);
        }
    }
}

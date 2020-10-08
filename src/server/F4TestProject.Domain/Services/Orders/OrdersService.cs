using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Orders.ServiceModels;
using F4TestProject.Infrastructure.Errors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IActionItemRepository _actionItemRepository;
        public OrdersService(IOrdersRepository ordersRepository, IActionItemRepository actionItemRepository)
        {
            _ordersRepository = ordersRepository;
            _actionItemRepository = actionItemRepository;
        }


        public async Task Create(OrderServiceModel order)
        {
            var actionItem = await _actionItemRepository.Get(order.ActionItemId);

            if (actionItem == null)
            {
                throw new EntryNotFoundException($"The entry with id '{order.ActionItemId}' was not found");
            }

            var newOrder = new Order()
            {
                ActionItem = actionItem,
                Customer = order.Customer,
                Tickets = order.Tickets
            };

            _ordersRepository.Create(newOrder);

            await _ordersRepository.SaveChanges();
        }

        public Task<IEnumerable<Order>> GetByCustomerId(Guid customerId)
        {
            return _ordersRepository.GetByCustomerId(customerId);
        }
    }
}

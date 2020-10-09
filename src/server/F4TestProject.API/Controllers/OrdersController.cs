using AutoMapper;
using F4TestProject.API.Attributes;
using F4TestProject.API.Middleware;
using F4TestProject.API.Models;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Orders;
using F4TestProject.Domain.Services.Orders.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace F4TestProject.API.Controllers
{
    /// <summary>
    /// Responsible of creating and viewing orders.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public OrdersController(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns orders of authorized user.
        /// </summary>
        [Authorize(Roles.Customer)]
        [HttpGet]
        [ProducesResponseType(typeof(OrderResponse[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IEnumerable<OrderResponse>> Get()
        {
            var customer = ControllerContext.HttpContext.GetUser();
            var result = await _ordersService.GetByCustomerId(customer.Id);
            return _mapper.Map<IEnumerable<OrderResponse>>(result);
        }

        /// <summary>
        /// Creates new order of authorized user.
        /// </summary>
        /// <param name="order"></param>
        [HttpPost]
        [Authorize(Roles.Customer)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task Post([FromBody] OrderRequest order)
        {
            var customer = ControllerContext.HttpContext.GetUser();
            await _ordersService.Create(new OrderServiceModel()
            {
                Customer = customer,
                ActionItemId = order.ActionItemId,
                Tickets = order.Tickets
            });
        }
    }
}

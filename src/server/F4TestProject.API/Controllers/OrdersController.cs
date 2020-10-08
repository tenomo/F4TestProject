using F4TestProject.API.Attributes;
using F4TestProject.API.Middleware;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F4TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET api/<OrdersController>/5
        [Authorize(Roles.Customer)]
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var customer = ControllerContext.HttpContext.GetUser();
            return await _ordersService.GetByCustomerId(customer.Id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        [Authorize(Roles.Customer)]

        public void Post([FromBody] Order order)
        {
        }
    }
}

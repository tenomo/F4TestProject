using AutoMapper;
using F4TestProject.API.Models;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services;
using F4TestProject.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace F4TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionItemsController : ControllerBase
    {
        private readonly IActionItemsService _actionItemsService;
        private readonly IMapper _mapper;
        public ActionItemsController(IActionItemsService actionItemsService, IMapper mapper)
        {
            _actionItemsService = actionItemsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PaginatedResult<ActionItem>> Get([FromQuery] ActionItemsFilter actionItemsFilter)
        {
            return await _actionItemsService.Get(actionItemsFilter.SearchValue, actionItemsFilter.Page, actionItemsFilter.Rows);
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] ActionItemRequest actionItemRequest)
        {

            return await _actionItemsService.Create(_mapper.Map<ActionItem>(actionItemRequest));
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] ActionItemRequest actionItemRequest)
        {
            var actionItem = _mapper.Map<ActionItem>(actionItemRequest);

            actionItem.Id = id;

            await _actionItemsService.Update(actionItem);
        }
    }
}

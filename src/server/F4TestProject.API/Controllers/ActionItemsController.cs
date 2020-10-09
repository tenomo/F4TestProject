using AutoMapper;
using F4TestProject.API.Attributes;
using F4TestProject.API.Models;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services;
using F4TestProject.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace F4TestProject.API.Controllers
{
    /// <summary>
    /// Responsible for ActionItems managing.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActionItemsController : ControllerBase
    {
        private readonly IActionItemsService _actionItemsService;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public ActionItemsController(IActionItemsService actionItemsService, IMapper mapper)
        {
            _actionItemsService = actionItemsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns paginated ActionItems.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ActionItemResponse>), (int)HttpStatusCode.OK)]
        public async Task<PaginatedResult<ActionItemResponse>> Get([FromQuery] ActionItemsFilter actionItemsFilter)
        {
            var result = await _actionItemsService.Get(actionItemsFilter.SearchValue, actionItemsFilter.Page, actionItemsFilter.Rows);

            var response = _mapper.Map<PaginatedResult<ActionItemResponse>>(result);

            return response;
        }

        /// <summary>
        /// Creates a new ActionItem.
        /// </summary>
        [HttpPost]
        [Authorize(Roles.Admin)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Guid> Post([FromBody] ActionItemRequest actionItemRequest)
        {
            return await _actionItemsService.Create(_mapper.Map<ActionItem>(actionItemRequest));
        }

        /// <summary>
        /// Updates an existing ActionItem by id.
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles.Admin)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Put([NoGuidEmpty] Guid id, [FromBody] ActionItemRequest actionItemRequest)
        {
            var actionItem = _mapper.Map<ActionItem>(actionItemRequest);

            actionItem.Id = id;

            await _actionItemsService.Update(actionItem);
        }
    }
}

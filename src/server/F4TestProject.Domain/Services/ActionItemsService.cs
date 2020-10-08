using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure.Pagination;
using System;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services
{
    public class ActionItemsService : IActionItemsService
    {
        private readonly IActionItemRepository _actionItemRepository;

        public ActionItemsService(IActionItemRepository actionItemRepository)
        {
            _actionItemRepository = actionItemRepository;
        }

        public Task<Guid> Create(ActionItem actionItem)
        {
            _actionItemRepository.Create(actionItem);
            return _actionItemRepository.SaveChanges().ContinueWith(task => { return actionItem.Id; });
        }

        public Task<PaginatedResult<ActionItem>> Get(string searchValues, int startOf, int rows)
        {
            return _actionItemRepository.Get(searchValues, startOf, rows);
        }


        public Task Update(ActionItem actionItem)
        {
            if (!_actionItemRepository.IsActionItemExisting(actionItem.Id).Result)
            {

            }
            _actionItemRepository.Update(actionItem);
            return _actionItemRepository.SaveChanges();
        }

    }
}

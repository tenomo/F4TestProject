using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure.Errors;
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
            if (_actionItemRepository.IsTitleUsing(actionItem.Title).Result)
            {
                throw new NotUniqueEntryException($"The title {actionItem.Title} is not unique");
            }

            _actionItemRepository.Create(actionItem);
            return _actionItemRepository.SaveChanges().ContinueWith(task => actionItem.Id);
        }

        public Task<PaginatedResult<ActionItem>> Get(string searchValues, int startOf, int rows)
        {
            return _actionItemRepository.Get(searchValues, startOf, rows);
        }


        public Task Update(ActionItem actionItem)
        {
            if (!_actionItemRepository.IsActionItemExisting(actionItem.Id).Result)
            {
                throw new EntryNotFoundException($"The entry with id {actionItem.Id} was not found");
            }
            _actionItemRepository.Update(actionItem);
            return _actionItemRepository.SaveChanges();
        }

    }
}

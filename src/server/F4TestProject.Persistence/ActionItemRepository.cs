using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F4TestProject.Persistence
{
    public class ActionItemRepository : IActionItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ActionItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task SaveChanges()
        {
            return _applicationDbContext.SaveChangesAsync();
        }

        public void Create(ActionItem actionItem)
        {
            _applicationDbContext.ActionItems.Add(actionItem);
        }

        public Task<PaginatedResult<ActionItem>> Get(string titleFilter, int page, int rows)
        {
            var itemActions = _applicationDbContext.ActionItems.AsNoTracking().Where(item =>
                item.Title.Contains(titleFilter) || item.Description.Contains(titleFilter));

            var countTask = itemActions.CountAsync();

            var queryResultTask = itemActions.Skip(PaginationHelper.RowsFrom(page, rows)).Take(rows).ToListAsync();

            var result = new TaskFactory().ContinueWhenAll(new Task[] { queryResultTask, countTask }, tasks =>
             {
                 var actionItems = ((Task<List<ActionItem>>)tasks[0]).Result;

                 var totalCount = ((Task<int>)tasks[1]).Result;

                 return new PaginatedResult<ActionItem>(actionItems, totalCount, page);
             });

            return result;
        }

        public Task<ActionItem> Get(Guid id)
        {
            return _applicationDbContext.ActionItems.FirstOrDefaultAsync(item => item.Id == id);
        }

        public void Update(ActionItem actionItem)
        {
            _applicationDbContext.Update(actionItem);
        }

        public Task<bool> IsActionItemExisting(Guid id)
        {
            return _applicationDbContext.ActionItems.AnyAsync(item => item.Id == id);
        }

        public Task<bool> IsTitleUsing(string title, Guid? exceptId = null)
        {
            return exceptId.HasValue
                ? _applicationDbContext.ActionItems.AnyAsync(item => item.Title.Equals(title) && item.Id != exceptId.Value)
                : _applicationDbContext.ActionItems.AnyAsync(item => item.Title.Equals(title));
        }
    }
}

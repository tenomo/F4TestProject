using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure;
using F4TestProject.Infrastructure.Pagination;
using System;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Data
{
    public interface IActionItemRepository : IRepository
    {
        void Create(ActionItem actionItem);
        Task<PaginatedResult<ActionItem>> Get(string titleFilter, int page, int rows);
        void Update(ActionItem actionItem);
        Task<bool> IsActionItemExisting(Guid id);
    }
}

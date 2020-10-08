using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure.Pagination;
using System;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services
{
    public interface IActionItemsService
    {
        Task<Guid> Create(ActionItem actionItem);
        Task<PaginatedResult<ActionItem>> Get(string searchValues, int startOf, int rows);
        Task Update(ActionItem actionItem);
    }
}

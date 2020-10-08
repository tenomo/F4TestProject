using System.Collections.Generic;

namespace F4TestProject.Infrastructure.Pagination
{
    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public int Rows { get; set; }
        public int TotalCount { get; }
        public IReadOnlyCollection<T> ResultCollection { get; }

        public PaginatedResult(IReadOnlyCollection<T> resultCollection, int totalCount, int pageNumber)
        {
            ResultCollection = resultCollection;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            Rows = resultCollection.Count;
        }
    }
}

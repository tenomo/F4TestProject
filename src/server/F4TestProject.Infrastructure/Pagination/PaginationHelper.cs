namespace F4TestProject.Infrastructure.Pagination
{
    public static class PaginationHelper
    {
        public static int RowsFrom(int page, int rows)
        {
            return rows * (page - 1);
        }
    }
}

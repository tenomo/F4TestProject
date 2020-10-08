namespace F4TestProject.API.Models
{
    public class ActionItemsFilter : PaginationRequest
    {
        private string _searchValue;

        /// <summary>
        /// The search string by details and title.
        /// </summary>
        public string SearchValue
        {
            get => _searchValue ?? string.Empty;
            set => _searchValue = value;
        }
    }
}

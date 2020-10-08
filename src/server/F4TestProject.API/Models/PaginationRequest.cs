using System.ComponentModel.DataAnnotations;

namespace F4TestProject.API.Models
{
    public class PaginationRequest
    {
        /// <summary>
        /// The number of page.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Page number value can can not be less than zero.")]
        public int Page { get; set; }

        /// <summary>
        /// The rows of page.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The rows of page value can not be less than zero.")]
        public int Rows { get; set; }
    }
}

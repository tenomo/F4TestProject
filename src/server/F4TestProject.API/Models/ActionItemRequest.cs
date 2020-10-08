using System;
using System.ComponentModel.DataAnnotations;

namespace F4TestProject.API.Models
{
    public class ActionItemRequest
    {
        private string _title;

        [Required]
        [StringLength(maximumLength: 128, MinimumLength = 1, ErrorMessage = "The title cannot be more than 128 characters and less than 1 character.")]
        public string Title
        {
            get => _title;
            set => _title = value.Trim();
        }

        [Required]
        public string Description { get; set; }

        [Required]

        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }

        [Required]
        [RegularExpression(@"(https?:\/\/.*\.(?:png|jpg))", ErrorMessage = "The field 'ImageLink' has a symbol/s that is not allowed.")]
        public string ImageLink { get; set; }
    }
}

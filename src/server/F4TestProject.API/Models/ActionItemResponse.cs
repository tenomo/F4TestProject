using System;

namespace F4TestProject.API.Models
{
    public class ActionItemResponse : ActionItemRequest
    {
        public Guid Id { get; set; }
        public int CountOfFreeSeats { get; set; }
    }
}

using F4TestProject.API.Attributes;
using System;

namespace F4TestProject.API.Models
{
    public class OrderRequest
    {
        [NoGuidEmpty]
        public Guid ActionItemId { get; set; }
        public short Tickets { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace F4TestProject.Domain.Models
{
    public class User
    {
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public Guid Id { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}

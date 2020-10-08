using Newtonsoft.Json;
using System;

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
    }
}

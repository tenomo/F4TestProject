using F4TestProject.Domain.Models;
using System;

namespace F4TestProject.Domain.Services.Users.ServiceModels
{
    public class AuthenticateResponse
    {
        public string Token { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Roles Role { get; }
        public Guid Id { get; }

        public AuthenticateResponse(User user, string token)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Id = user.Id;
            Token = token;
        }
    }
}

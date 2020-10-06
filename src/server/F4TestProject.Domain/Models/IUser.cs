using System;

namespace F4TestProject.Domain.Models
{
    public interface IUser
    {
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        Roles Role { get; }
        Guid Id { get; }
    }
}
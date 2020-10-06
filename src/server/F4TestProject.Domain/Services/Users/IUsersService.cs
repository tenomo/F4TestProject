using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Users.ServiceModels;
using System;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services.Users
{
    public interface IUsersService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest);
        Task<AuthenticateResponse> Register(UserRegisterRequest registerRequest);
        Task<User> GetById(Guid id);
    }
}

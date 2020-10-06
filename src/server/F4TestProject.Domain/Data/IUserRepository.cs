using F4TestProject.Domain.Models;
using F4TestProject.Infrastructure;
using System;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Data
{
    public interface IUserRepository : IRepository
    {
        void Create(User user);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
    }
}

using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace F4TestProject.Persistence
{
    public class UsersRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsersRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(User user)
        {
            _applicationDbContext.Users.Add(user);
        }

        public Task<User> GetById(Guid id)
        {
            return _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public Task<User> GetByEmail(string email)
        {
            return _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public Task SaveChanges()
        {
            return _applicationDbContext.SaveChangesAsync();
        }
    }
}

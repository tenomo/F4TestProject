using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Users.ServiceModels;
using F4TestProject.Infrastructure;
using F4TestProject.Infrastructure.Errors;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace F4TestProject.Domain.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _users;
        private readonly AppSettings _appSettings;

        public UsersService(IOptions<AppSettings> appSettings, IUserRepository users)
        {
            _users = users;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest)
        {
            var user = await _users.GetByEmail(authenticateRequest.Email);

            if (user == null)
            {
                throw new AuthenticationFailedException();
            };

            if (!BCrypt.Net.BCrypt.Verify(authenticateRequest.Password, user.PasswordHash))
            {
                throw new AuthenticationFailedException();
            }

            var token = CreateAuthenticateResponse(user);

            return CreateAuthenticateResponse(user);
        }

        public async Task<AuthenticateResponse> Register(UserRegisterRequest registerRequest)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
            var user = new User()
            {
                Role = Roles.Customer,
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                PasswordHash = passwordHash
            };
            _users.Create(user);
            await _users.SaveChanges();
            return CreateAuthenticateResponse(user);
        }


        public Task<User> GetById(Guid id)
        {
            return _users.GetById(id);
        }


        private AuthenticateResponse CreateAuthenticateResponse(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()) ,
                    new Claim("id", user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new AuthenticateResponse(user, tokenString);
        }
    }
}

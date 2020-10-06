using F4TestProject.API.Attributes;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Users;
using F4TestProject.Domain.Services.Users.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace F4TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest authenticateRequest)
        {
            return Ok(await _usersService.Authenticate(authenticateRequest));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            return Ok(await _usersService.Register(userRegisterRequest));
        }


        [HttpGet("{id}")]
        [Authorize(Roles.Customer)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _usersService.GetById(id));
        }
    }
}

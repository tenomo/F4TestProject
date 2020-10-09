using F4TestProject.API.Attributes;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services.Users;
using F4TestProject.Domain.Services.Users.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace F4TestProject.API.Controllers
{
    /// <summary>
    /// Responsible for user managing.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        /// <inheritdoc />
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Authenticate an existing user.
        /// </summary>
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Authenticate(AuthenticateRequest authenticateRequest)
        {
            return Ok(await _usersService.Authenticate(authenticateRequest));
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            return Ok(await _usersService.Register(userRegisterRequest));
        }

        /// <summary>
        /// Returns user by id.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles.Customer)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _usersService.GetById(id));
        }
    }
}

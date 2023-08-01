using Core.Models;
using Data.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MPED.Task.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPED.Task.Api.Controllers
{
    [ApiController]
    //[Route("[api/v1/users]")]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService usersService;


        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            this.usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserModel user)
        {
            await usersService.CreateAsync(new User { Email = user.Email, Gender = user.Gender, Location = user.Location, Message = user.Message, PhoneNumber = user.PhoneNumber, UserName = user.Email }, user.Password);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserModel user)
        {
            var result = await usersService.Login(user.Email, user.Password);
            if (result is null || !result.IsLogin)
                return Unauthorized();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            await usersService.GetByIdAsync(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(usersService.GetAll());
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(UserModel user)
        {
            await usersService.UpdateAsync(new User
            {
                Email = user.Email,
                Gender = user.Gender,
                Location = user.Location,
                Message = user.Message,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Email,
                Id = user.Id
            }
            );
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await usersService.DeleteAsync(id);
            return Ok();

        }
    }
}

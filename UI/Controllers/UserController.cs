using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using UI.Authorization;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("create")]
        [PermissionAuthorize("User.Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto user)
        {
            ResponseDto response = new();
            response = await _userService.InsertUser(user);

            if (!response.Completed)
                return BadRequest(response);

            return Ok(response);
        }
    }
}

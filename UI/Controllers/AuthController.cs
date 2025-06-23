using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            ResponseDataDto<string> response = new();
            response = await _authService.LoginAsync(request.Email, request.Password);

            if (!response.Completed)
                return NotFound(response);
            if (response.Data == null)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}

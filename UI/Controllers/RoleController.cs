﻿using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using UI.Authorization;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController(IRoleService roleService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;

        [HttpGet("getall")]
        [PermissionAuthorize("User.Create")]
        public async Task<IActionResult> GetAll()
        {
            ResponseDataDto<List<RoleDto>> response = new();
            response = await _roleService.GetAllRolesAsync();

            if (!response.Completed)
                return NotFound(response);

            return Ok(response);
        }
    }
}

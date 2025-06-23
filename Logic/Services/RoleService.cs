using DataAccess.Entities;
using DataAccess.Interfaces;
using Logic.Interfaces;
using Shared.DTOs;

namespace Logic.Services
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task<ResponseDataDto<List<RoleDto>>> GetAllRolesAsync()
        {
            ResponseDataDto<List<RoleDto>> response = new();
            List<Role> roles = await _roleRepository.GetAllRoles();
            if (roles == null || roles.Count == 0)
            {
                response.Data = [];
                response.Message = "No se encontraron roles";
                response.Completed = true;
                return response;
            }
            response.Data = [.. roles.Select(p => new RoleDto
                {
                    IdRole = p.IdRole,
                    Name = p.Name
                })];
            response.Message = "Roles obtenidos exitosamente";
            response.Completed = true;
            return response;
        }
    }
}

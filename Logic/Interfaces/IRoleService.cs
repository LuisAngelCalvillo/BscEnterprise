using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IRoleService
    {
        Task<ResponseDataDto<List<RoleDto>>> GetAllRolesAsync();
    }
}

using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
    }
}

using DataAccess.Entities;
using Shared.DTOs;
using System.Data;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<UserLoginDto> GetByEmailAsync(string email);
        Task<List<string>> GetPermissionsByUserIdAsync(int userId);
        Task<bool> InsertAsync(User user, IDbTransaction transaction);
    }
}

using Dapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Shared.DTOs;
using System.Data;

namespace DataAccess.Repositories
{
    public class UserRepository(IDbConnection dbConnection) : IUserRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<UserLoginDto> GetByEmailAsync(string email)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Email", email);
            return await _dbConnection.QueryFirstOrDefaultAsync<UserLoginDto>("Usp_UserLoginGet", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<string>> GetPermissionsByUserIdAsync(int userId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@UserId", userId);
            IEnumerable<string> permissions = await _dbConnection.QueryAsync<string>("Usp_PermissionGet", parameters, commandType: CommandType.StoredProcedure);
            return [.. permissions];
        }

        public async Task<bool> InsertAsync(User user, IDbTransaction transaction)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Email", user.Email);
            parameters.Add("@Name", user.Name);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Password", user.Password);
            parameters.Add("@IsActive", user.IsActive);
            parameters.Add("@RoleId", user.RoleId);
            int Result = await _dbConnection.QuerySingleAsync<int>("Usp_UserInsert", parameters, transaction, commandType: CommandType.StoredProcedure);
            return Result > 0;
        }
    }
}

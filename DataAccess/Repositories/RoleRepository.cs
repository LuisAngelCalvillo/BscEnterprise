using Dapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System.Data;

namespace DataAccess.Repositories
{
    public class RoleRepository(IDbConnection dbConnection) : IRoleRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<List<Role>> GetAllRoles()
        {
            IEnumerable<Role> roles = await _dbConnection.QueryAsync<Role>("Usp_RoleGet", commandType: CommandType.StoredProcedure);
            return [.. roles];
        }
    }
}

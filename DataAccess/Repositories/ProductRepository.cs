using Dapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Shared.DTOs;
using System.Data;
using System.Data.Common;

namespace DataAccess.Repositories
{
    public class ProductRepository(IDbConnection dbConnection) : IProductRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<List<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = await _dbConnection.QueryAsync<Product>("Usp_ProductGet", commandType: CommandType.StoredProcedure);
            return [.. products];
        }

        public async Task<bool> InsertAsync(Product product, IDbTransaction transaction)
        {
            DynamicParameters parameters = new();
            parameters.Add("@ProductKey", product.ProductKey);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Stock", product.Stock);
            parameters.Add("@IsActive", product.IsActive);
            int Result = await _dbConnection.QuerySingleAsync<int>("Usp_ProductInsert", parameters, transaction, commandType: CommandType.StoredProcedure);
            return Result > 0;
        }
    }
}

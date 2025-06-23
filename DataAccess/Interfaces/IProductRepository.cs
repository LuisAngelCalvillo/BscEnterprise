using DataAccess.Entities;
using Shared.DTOs;
using System.Data;

namespace DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<bool> InsertAsync(Product product, IDbTransaction transaction);
    }
}

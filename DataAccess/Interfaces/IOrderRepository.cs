using DataAccess.Entities;
using Shared.DTOs;
using System.Data;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<bool> InsertAsync(Order order, DataTable table, IDbTransaction transaction);
        Task<List<DetailOrderResponse>> GetDetailOrder(int idOrder);
    }
}

using Dapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Shared.DTOs;
using System.Data;

namespace DataAccess.Repositories
{
    public class OrderRepository(IDbConnection dbConnection) : IOrderRepository
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<List<Order>> GetAllOrders()
        {
            IEnumerable<Order> orders = await _dbConnection.QueryAsync<Order>("Usp_OrderGet", commandType: CommandType.StoredProcedure);
            return [.. orders];
        }

        public async Task<bool> InsertAsync(Order order, DataTable orderItems, IDbTransaction transaction)
        {
            DynamicParameters parameters = new();
            parameters.Add("@CustomerName", order.CustomerName);
            parameters.Add("@OrderNumber", order.OrderNumber);
            parameters.Add("@Date", order.Date);
            parameters.Add("@Items", orderItems.AsTableValuedParameter("OrderItemType"));
            int Result = await _dbConnection.QuerySingleAsync<int>("Usp_OrderInsert", parameters, transaction, commandType: CommandType.StoredProcedure);
            return Result > 0;
        }

        public async Task<List<DetailOrderResponse>> GetDetailOrder(int idOrder)
        {
            DynamicParameters parameters = new();
            parameters.Add("@OrderId", idOrder);
            IEnumerable<DetailOrderResponse> orderDetail = await _dbConnection.QueryAsync<DetailOrderResponse>("Usp_OrderDetailGet", parameters, commandType: CommandType.StoredProcedure);
            return [.. orderDetail];
        }
    }
}

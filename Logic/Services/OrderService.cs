using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Logic.Interfaces;
using Shared.DTOs;
using System.Data;
using System.Data.Common;

namespace Logic.Services
{
    public class OrderService(IOrderRepository orderRepository, IDbConnection dbConnection) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<ResponseDataDto<List<OrderDto>>> GetAllOrdersAsync()
        {
            ResponseDataDto<List<OrderDto>> response = new();
            List<Order> orders = await _orderRepository.GetAllOrders();
            if (orders == null || orders.Count == 0)
            {
                response.Data = [];
                response.Message = "No se encontraron pedidos";
                response.Completed = true;
                return response;
            }
            response.Data = [.. orders.Select(p => new OrderDto
                {
                    IdOrder = p.IdOrder,
                    OrderNumber = p.OrderNumber,
                    CustomerName = p.CustomerName,
                    OrderDate = p.Date
                })];
            response.Message = "Pedidos obtenidos exitosamente";
            response.Completed = true;
            return response;
        }

        public async Task<ResponseDto> InsertOrderAsync(InsertOrderDetailDto orderDetail)
        {
            ResponseDto response = new();
            _dbConnection.Open();
            using var transaction = _dbConnection.BeginTransaction();

            try
            {
                Order orderEntitie = new()
                {
                    CustomerName = orderDetail.CustomerName,
                    OrderNumber = orderDetail.OrderNumber,
                    Date = DateTime.Now,
                };

                var orderItems = new DataTable();
                orderItems.Columns.Add("Quantity", typeof(int));
                orderItems.Columns.Add("ProductId", typeof(int));

                foreach (var item in orderDetail.OrderItems)
                {
                    orderItems.Rows.Add(item.ProductId, item.Quantity);
                }

                response.Completed = await _orderRepository.InsertAsync(orderEntitie, orderItems, transaction);

                if (!response.Completed)
                {
                    response.Message = "No se pudo registrar el pedido debido a stock insuficiente";
                    transaction.Rollback();
                    return response;
                }

                transaction.Commit();
                response.Message = "Se registro exitosamente el pedido";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al registrar el pedido: " + ex.Message;
                transaction.Rollback();
                return response;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public async Task<ResponseDataDto<List<DetailOrderResponse>>> GetDetailOrder(int idOrder)
        {
            ResponseDataDto<List<DetailOrderResponse>> response = new();
            List<DetailOrderResponse> orders = await _orderRepository.GetDetailOrder(idOrder);
            if (orders == null || orders.Count == 0)
            {
                response.Data = [];
                response.Message = "No se encontro el pedido en el sistema.";
                response.Completed = true;
                return response;
            }
            response.Data = orders;
            response.Message = "Detalle de pedido obtenido exitosamente.";
            response.Completed = true;
            return response;
        }
    }
}
